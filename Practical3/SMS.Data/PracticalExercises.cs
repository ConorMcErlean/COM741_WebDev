using System;
using System.Linq;
using System.Collections.Generic;

using SMS.Data.Models;
using SMS.Data.Repositories;

namespace SMS.Data
{
    class PracticalExercises
    {
        // the context which connects us via entityframework to the underlying database
        private DatabaseContext ctx = new DatabaseContext();
        

        // Q1 - Each time we Initialise the database all data is lost. This convenience method adds some 
        //      sample data to the database during development process.
        public void Seed()
        {
            // initialise the database
            
            ctx.Initialise();

            // create the students
           var s1 = new Student{Name = "Homer", Course = "Computing", Age = 45};
           var s2 = new Student{Name = "Marge", Course = "Engineering", 
                                Age = 40};
           var s3 = new Student{Name = "Bart", Course = "Philosophy", Age = 16};
           var s4 = new Student{Name = "Lisa", Course = "Computing", Age = 14};

            // add the students
            ctx.Add(s1);
            ctx.Add(s2);
            ctx.Add(s3);
            ctx.Add(s4);

            // save the changes
           ctx.SaveChanges();
        }

 
        // Q2 print student details in format Id - Name - Course - Age 
        public void PrintStudents()
        {
            // Access
            var Students = ctx.Students.Select(s => s).ToList();
            // Print
            PrintListOfStudents(Students);
        }


        // Q3 - print student with specified id if found, otherwise print Not found 
        public void  PrintStudentById(int id)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Not Found");
            }   
        }


        // Q4 - return all students taking specific course - 2 Computing 
        public void PrintStudentsTakingCourse(string course)
        {
             // Check
            var Students = ctx.Students.Where(s => s.Course.Contains(course))
            .ToList();
            // Print
            PrintListOfStudents(Students);
             
        }

        // Q5 - print all adults (>=18) taking course - 1 computing
        public void PrintAdultStudentsTakingCourse(string course)
        {
    
             // Check
            var Students = ctx.Students.Where(s => s.Course == course &&
            s.Age >= 18).ToList();
            // Print
            PrintListOfStudents(Students);
            
        } //PrintAdultStudentsTakingCourse

        // Q6 - update the student details (not the id)
        public Student UpdateStudent(int id, string name, string course, int age)
        {
            // verify student with id exists
            
            var student = ctx.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                 Console.WriteLine("Not Found");
                 return null;
            }
            else
            {
                // update student that has been loaded
                student.Name = name;
                student.Course = course;
                student.Age = age;
                // save changes and return updated student
                ctx.SaveChanges();
                return student;
            }
        }
    
        // Q6 - Test method to verify operation of Updating a student
        public void TestUpdateStudent()
        {
            // Seed();
            // retrieve student 1 “Homer” 
            var homer = GetStudentByName("Homer");
            
            // update homer - adding 1 to his age and set his course to Physics
            homer.Age = homer.Age +1;
            homer.Course = "Physics";
            
            // save updated homer by calling the UpdateStudent method passing parameters from homer
            UpdateStudent(homer.Id, homer.Name, homer.Course, homer.Age);
            // then print to ensure updates were saved

            var updatedHomer = GetStudentByName("Homer");
            Console.WriteLine(updatedHomer);
           
        }

        // Q7  - delete the student identified by id
        //       load the student and if not found then return false
        //       otherwise remove the student, save the changes and return true 
        public bool DeleteStudent(int id)
        {
            // verify student exists and if not return false
            var student = ctx.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                 Console.WriteLine("Not Found");
                 return false;
            }
            else
            {
            // remove student
            ctx.Students.Remove(student);

            // save changes
            ctx.SaveChanges();

            return true; 
            }  //else
        }

        // Q7 - Test method to verify operation of deleting a student
        public void TestDeleteStudent()
        {
            // delete student 1 ("Homer')
            var worked = DeleteStudent(1);
            // verify deleteStudent returned true and print appropriate message
           if (worked == true)
           {
               Console.WriteLine("Delete Successful" 
               + "\n\t Table Now:");
               PrintStudents();
           }
           else{
               Console.WriteLine("Delete Unsuccessful");
           }
        }

        // Q8 - optional
        public void PrintListOfStudents(IList<Student> students)
        {
            // Print Header
               Console.WriteLine("Id\tName\tCourse\t\tAge" + 
                                "\n===================================");
            // Print Contents
            foreach (var S in students)
            {
                Console.WriteLine($"{S.Id}\t{S.Name}\t{S.Course}\t{S.Age}");
            }
        }
        
        public Student GetStudentByName(String name)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Name == name);
            return student;
        }
    }

}// Namespace
