using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using SMS.Data.Repositories;
using SMS.Data.Models;

namespace SMS.Data
{
    public  class PracticalQueries
    {
        private readonly DatabaseContext db;

        public PracticalQueries()
        {
            db = new DatabaseContext();
               
        }
        
        // Each time we Initialise the database all data is lost. 
        // This convenience method adds some sample data to the database
        // during development process.
        public void Seed()
        {
            db.Initialise(); // recreate the database

            // Create some students with related profile and add to the Students DbSet 
            var s1 = new Student {  Name = "Homer",
                                    Course = "Computing",
                                    Age = 44,
                                    Profile = new Profile { Grade = 45.0 }
            };   
            var s2 = new Student {  Name = "Marge",
                                    Course = "Engineering",
                                    Age = 40,
                                    Profile = new Profile { Grade = 68.0 }
            };
            var s3 = new Student {
                                    Name = "Bart",
                                    Course = "Sleeping",
                                    Age = 13,
                                    Profile = new Profile { Grade = 39.0 }
            };
            var s4 = new Student { Name = "Lisa",
                                   Course = "Computing",
                                   Age = 10,
                                   Profile = new Profile { Grade = 86.0 }
            };

            // Add students to the Students DbSet 
            db.Students.AddRange(s1,s2,s3,s4);

            db.SaveChanges();

            // Add some tickets for Homer
            db.Tickets.Add( new Ticket
            {
                StudentId = s1.Id,
                Issue = "I need some Beer",
                CreatedOn = new DateTime(2020, 2, 5),
                Active = false
            });

            db.Tickets.Add( new Ticket
            {
                StudentId = s1.Id,
                Issue = "Bart you little ...",
                CreatedOn = new DateTime(2020, 2, 2),
                Active = true
            });

            // Add a ticket for Bart 
            db.Tickets.Add( new Ticket
            {
                StudentId = s3.Id,
                Issue = "Go to skinners office",
                CreatedOn = new DateTime(2020, 2, 1),
                Active = true
            });

            db.SaveChanges();

            // create some modules
            var m1 = new Module { Title = "Programming" };
            var m2 = new Module { Title = "Maths" };
            var m3 = new Module { Title = "English" };

            // add all modules to the Modules DbSet
            db.Modules.AddRange(m1, m2, m3);
            db.SaveChanges();

            // Homer is taking Programming 
            db.StudentModules.Add(new StudentModule { StudentId = s1.Id, ModuleId = m1.Id });

            // Marge is taking Maths
            db.StudentModules.Add(new StudentModule { StudentId = s3.Id, ModuleId = m2.Id });

            // Bart is taking English 
            db.StudentModules.Add( new StudentModule { StudentId = s3.Id, ModuleId = m3.Id});
          
            // Lisa is Taking Programming Maths and English
            db.StudentModules.Add( new StudentModule { StudentId = s4.Id, ModuleId = m1.Id} );
            db.StudentModules.Add( new StudentModule { StudentId = s4.Id, ModuleId = m2.Id} );
            db.StudentModules.Add( new StudentModule { StudentId = s4.Id, ModuleId = m3.Id} );

            db.SaveChanges();
        }

        // -------------------- Student Queries --------------------------

        // Q1 - 
        public void StudentsWithProfile()
        {
             Console.WriteLine("\nPrint All Students and Their Profile Grade");
            // retrieve all students and their associated Profile (use the Include method)

                        
            // loop through the list of students returned and print each student and their profile grade            

        }


        // Q2 - Print Name and Grade of All Students who failed (<40)
        public void StudentsFailing()
        {
            Console.WriteLine("\nPrint Name and Grade Of All Students Who Failed");
            

          
        }


        // Q3 - Select and print Name and Grade of Adult Students (Age >= 18) Who Passed (Grade >=40)
        public void AdultStudentsPassing()
        {           
            Console.WriteLine("\nThe Adults Who Passed");
            
        }

        // Q3 OPTIONAL 
        public void AdultStudentsPassingProjection()
        {
            // we can use more complex queries as follows
            Console.WriteLine("\nThe Adults Who Passed");
            
        }

        // ----------------------- Ticket Queries -------------------------

        // Q4 - Select and print Ticket Issue, Student Name, and Ticket CreatedOn Date for all Tickets
        public void TicketsWithStudent()
        {
            Console.WriteLine("\nAll Tickets With Related Student");
            
        }

        // Q5 - Select and print Student Name, Issue and CreatedOn for Active tickets
        public void ActiveTicketsWithStudent()
        {
            Console.WriteLine("\nActive Tickets With Name and Issue");
            
        }

        // Q5 - OPTIONAL
        public void ActiveTicketsWithStudentProjection()
        {
            Console.WriteLine("\nActive Tickets With Name and Issue");
            
        }


        // Q6 Return Student Name, Issue and CreatedOn for open tickets Created Before Specified Date
        public void ActiveTicketsBeforeDate(DateTime date)
        {
            Console.WriteLine("\nActive Tickets With Name and Issue Created Before " + date);
            
        }

        // ----------------------------- StudentModule Queries ----------------

        // Q7 Return All StudentModules with related Student and Module Details ordered by student
        public void AllStudentModulesOrderedByStudent()
        {
            Console.WriteLine("\nThe Student Modules");
            
        }

        // Q8 return all student modules with related module taken by named student
        public void ModulesTakenByStudent(string name)
        { 
            Console.WriteLine("\nModules Taken By " + name);
            
            
        }

        // Q9 print names of all students taking Computing
        public void StudentsTakingModule(string module)
        {    
            Console.WriteLine("\nStudents Taking " + module);
            

        }
    }
}
