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
                              .FirstOrDefault(s => s.Id == id);
        }

        // Add a new student and create a related profile setting the Grade 
        public Student AddStudent(string name, string course, int age, 
                        double grade)
        {
            // create student
            var s = new Student
                {
                    Name = name,
                    Course = course,
                    Age = age,
                    Profile = new Profile{Grade = grade}
                };
            // add to db
            db.Students.Add(s);
            // save changes
            db.SaveChanges();
            return s; // return newly added student
        }

        // Delete the student identified by Id returning true if deleted and false if not found
        public bool DeleteStudent(int id)
        {
            // search for student
            var s = db.Students.FirstOrDefault(s => s.Id == id);

            // if not found return false
            if ( s == null){
                return false;
            }
            // remove the student from db and save changes
            db.Students.Remove(s);
            db.SaveChanges();
            return true;
        }

        // Update the student student identified by id with the details in updated 
        public Student UpdateStudent(int id, Student updated)
        {
            // verify the student exists
            var s = db.Students.FirstOrDefault(s => s.Id == id);
            // if doesnt exist return null
            if ( s == null){return null;}
            // update the details of the student retrieved and save changes
            s = updated;
            db.SaveChanges();
            // return updated student
            s = db.Students.First(s => s.Id == id);
            return s;
        }

        // ----------------------- Module Related Operations ---------------------

        public Module AddModule(string title)
        {
            // create module
            var m = new Module{Title = title};

            // add to database and save changes
            db.Modules.Add(m);
            db.SaveChanges();
            // return new module
            return m;
        }

        public StudentModule AddStudentToModule(int studentId, int moduleId)
        {
            // check if this student module already exists and return null if 
            // found
           var sm = db.StudentModules.FirstOrDefault(sm => 
                    (sm.Module.Id == moduleId) && 
                    sm.Student.Id == studentId);
            if (sm != null){
                return null;
            }
            // locate the student and the module
            var s = db.Students.FirstOrDefault(s => s.Id == studentId);
            var m = db.Modules.FirstOrDefault(m => m.Id == moduleId);
            // if either don't exist then return null
           if ( s == null || m == null){ return null; }
            // create the student module and add to database saving changes
            sm = new StudentModule
            {
                Student = s,
                Module = m 
            };
            db.StudentModules.Add(sm);
            db.SaveChanges();
            // return new module
            return sm;
        }

        public bool RemoveStudentFromModule(int studentId, int moduleId)
        {
            // find student module and if not found return false
            var sm = db.StudentModules.FirstOrDefault(sm => 
                    (sm.Module.Id == moduleId) && 
                    sm.Student.Id == studentId);
            if (sm == null){
                return false;
            }
            // remove student module from database and save changes
            db.StudentModules.Remove(sm);
            db.SaveChanges();
            return true;
        }

        // ---------------------- Ticket Management --------------------------

        // Return all Open Tickets (Active) with Related Students and their Profiles
        public IList<Ticket> GetOpenTickets()
        {
            // return open tickets with associated student and Student Profile
            return db.Tickets.Include(t => t.Student)
                            .Include(t => t.Student.Profile)
                            .Where(t => t.Active == true)
                            .ToList();
        }
        
        public Ticket CreateTicket(int studentId, string issue)
        {
            // verify student exists and if not return null
            var s = db.Students.FirstOrDefault(s => s.Id == studentId);
            if (s == null)
            {
                return null;
            }
            // create ticket
            var t = new Ticket
            {
                Issue = issue,
                Student = s,
                Active = true
            };

            // add ticket and save changes
            db.Tickets.Add(t);
            db.SaveChanges();

            // return new ticket
            return t;
        }  

        public Ticket CloseTicket(int id)
        {
            // check if this ticket exists and is currently open
            var t = db.Tickets.FirstOrDefault (t => t.Id == id);
            // if not return null
            if (t == null)
            {
                return null;
            }
            // set ticket status to inactive
            t.Active = false;
            // update the database and save changes
            db.SaveChanges();
            // return updated ticket
            return t;
        }


        // Return all Tickets with Related Student and Student Profile
        public IList<Ticket> GetAllTickets()
        {
            // return open tickets with associated student
            return db.Tickets.Include(t => t.Student)
                            .Include(t => t.Student.Profile)
                            .ToList();
        }
        

    }
}