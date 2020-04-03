using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using SMS.Data.Models;
using SMS.Data.Repositories;

namespace SMS.Data.Services
{
    public class StudentService : IStudentService
    {
        private readonly DatabaseContext db;

        public StudentService()
        {
            db = new DatabaseContext();
        }

        public void Initialise()
        {
            db.Initialise();
        }

        // ------------------ Student Related Operations ------------------------

        // retrieve list of Students with their related Profile
        public IList<Student> GetAllStudents()
        {
            return db.Students
                     .Include(s => s.Profile)
                     .ToList();
        }


        // Retrive student by Id with related Profile and Lists of Tickets and StudentModules
        public Student GetStudent(int id)
        {
            return db.Students.Include(s => s.Profile)
                              .Include(s => s.Tickets)
                              .Include(s => s.StudentModules)
                              .ThenInclude(sm => sm.Module) // drill down and include each studentmodule module entity
                              .FirstOrDefault(s => s.Id == id);
        }

        // Add a new student and create a related profile setting the Grade 
        public Student AddStudent(string name, string email, string course, int age, double grade)
        {
            // verify that a student with same email does not exist
            var exists = db.Students.FirstOrDefault(o => o.Email == email);
            if (exists != null)
            {
                return null;
            }

            var s = new Student
            {
                Name = name,
                Email = email, /** new unique email property **/
                Course = course,
                Age = age,
                Profile = new Profile { Grade = grade },
            };
            db.Students.Add(s);
            db.SaveChanges();
            return s; // return newly added student
        }

        // Delete the student identified by Id returning true if deleted and false if not found
        public bool DeleteStudent(int id)
        {
            var s = GetStudent(id);
            if (s == null)
            {
                return false;
            }
            db.Students.Remove(s);
            db.SaveChanges();
            return true;
        }

        // Update the student student identified by id with the details in updated 
        public Student UpdateStudent(int id, Student updated)
        {
            // verify the student exists
            var student = GetStudent(id);
            if (student == null)
            {
                return null;
            }
            // update the details of the student retrieved and save
            student.Name = updated.Name;
            student.Age = updated.Age;
            student.Email = updated.Email;
            student.Course = updated.Course;
            student.Profile.Grade = updated.Profile.Grade;
            db.SaveChanges();
            return student;
        }

        /** New Method **/
        public Student RecalculateStudentGrade(int studentId)
        {
            // retrieve the student identified by studentId
            var student = GetStudent(studentId);
            // check the student exists
            if (student == null)
            {
                return null; // no such student
            }

            // calculate sum of module marks and count number of modules
            var sum = student.StudentModules.Sum(sm => sm.Mark);
            var count = student.StudentModules.Count();
            var avg = count == 0 ? 0 : sum / count;

            // set the student Profile Grade with average of module grades or 0 if no modules
            student.Profile.Grade = avg; 

            // save the changes
            db.SaveChanges();

            // return the updated student
            return student;
        }


        // ----------------------- Module Related Operations ---------------------

        public Module AddModule(string title)
        {
            var m = new Module { Title = title };
            db.Modules.Add(m);
            db.SaveChanges();

            return m;
        }

        public StudentModule AddStudentToModule(int studentId, int moduleId)
        {
            // check if this student module already exists and return null if found
            var sm = db.StudentModules
                       .FirstOrDefault(o => o.StudentId == studentId && o.ModuleId == moduleId);
            if (sm != null)
            {
                return null;
            }

            //// locate the student and the module
            var s = GetStudent(studentId);
            var m = db.Modules.FirstOrDefault(m => m.Id == moduleId);
            // if either don't exist then return null
            if (s == null || m == null)
            {
                return null;
            }

            // create the student module and add to database (either of following are fine)
            //var nsm = new StudentModule { StudentId = s.Id, ModuleId = m.Id};
            var nsm = new StudentModule { Student = s, Module = m };
            db.StudentModules.Add(nsm);

            db.SaveChanges();

            RecalculateStudentGrade(s.Id);

            return nsm;
        }

        public bool RemoveStudentFromModule(int studentId, int moduleId)
        {
            var sm = db.StudentModules
                       .FirstOrDefault(m => m.StudentId == studentId && m.ModuleId == moduleId);
            if (sm == null)
            {
                return false;
            }
            db.StudentModules.Remove(sm);
            db.SaveChanges();

            // need to recalculate the student grade
            RecalculateStudentGrade(sm.StudentId);

            return true;
        }

        /** New Method **/
        public StudentModule UpdateStudentModuleMark(int studentId, int moduleId, double mark)
        {
            var sm = db.StudentModules.FirstOrDefault(o => o.StudentId == studentId && o.ModuleId == moduleId);
            if (sm == null)
            {
                return null; // no such student module
            }
            sm.Mark = mark;
            db.SaveChanges();

            // need to Recalculate the student grade           
            RecalculateStudentGrade(studentId);

            return sm;
        }

        // ---------------------- Ticket Management --------------------------

        public Ticket CreateTicket(int studentId, string issue)
        {
            // verify student
            var s = GetStudent(studentId);
            if (s == null)
            {
                return null;
            }
            // create ticket
            var t = new Ticket
            {
                Issue = issue,
                CreatedOn = DateTime.Now,
                Active = true,
                StudentId = studentId
            };

            // add ticket
            db.Tickets.Add(t);
            db.SaveChanges();
            return t;
        }

        public Ticket CloseTicket(int id)
        {
            // check if this ticket exists and is currently open
            var ticket = db.Tickets.FirstOrDefault(t => t.Id == id && t.Active);
            if (ticket == null)
            {
                return null;
            }
            // set ticket status to inactive
            ticket.Active = false;
            // update the database
            db.SaveChanges();
            // return updated ticket
            return ticket;
        }


        // Return all Tickets with Related Student and Student Profile
        public IList<Ticket> GetAllTickets()
        {
            // return open tickets with associated student
            return db.Tickets
                    .Include(t => t.Student) // include the student
                    .Include(t => t.Student.Profile) // then include the student profile
                    .ToList();
        }

        // Return all Open Tickets (Active) with Related Students and their Profiles
        public IList<Ticket> GetOpenTickets()
        {
            // return open tickets with associated student and Student Profile
            return db.Tickets
                    .Include(t => t.Student) // include the student
                    .Include(t => t.Student.Profile) // then include the student profile
                    .Where(t => t.Active)
                    .ToList();
        }
    }
   
}