using System;
using System.Linq;  // provides Linq Collection extension methods
using System.Collections.Generic;

using Client.Data; // where our student classe is defined
using Client.Misc; // where our List ToPrettyString extension method is defined 

namespace Client  {
    class Program
    {
        public static void Main (string[] args)
        {
            // call relevant methods here to test
            
            // Question2();
            // Question5();
            Question6();

        }

        // Construct and return an int List
        public static List<int> BuildList()
        {
            // create initial list using list initialisation syntax 
            // and return replacing return statement below
            var numbers = new List<int>{24, 4, 7, 12, 45};
            
            // add 7 to position 0 (beginning of list)
            numbers.Insert(0, 7);

            // add 19 to end of list
            numbers.Insert(numbers.Count, 19);
            // Could also have used:
            // numbers.Add(19);
           
            // add element 1 at position 4
            numbers.Insert(4, 1);
           
            // finally return the new list you created rather than null
            return numbers;
        }

        // construct an return a Student List
        public static List<Student> BuildStudentList()
        {
            // create initial list using list initialisation syntax and return 
            // replacing return statement below
            var StudentList = new List<Student>
            {
                new Student{Id = 23, Name = "Homer", Age = 44},
                new Student{Id = 12, Name = "Marge", Age = 39},
                new Student{Id = 31, Name = "Bart", Age = 12},
                new Student{Id = 16, Name = "Lisa", Age = 10},
            };

            return StudentList; // return the list you created rather than null
        }

        public static void Question2()
        {
            Console.WriteLine("\nQuestion 3");
            
            // call buildlist to construct and return a sample list
           var TheList = BuildList();
         
            // q2 a
            Console.WriteLine(TheList.ToPrettyString());

            // q2 b
            foreach(var a in TheList)
            {
                if (a > 15)
                {
                    Console.Write(a + " ");
                }// if
            
            }// foreach
            Console.WriteLine();
        
            // q2 c
           foreach (var a in TheList)
           {
               if (a < 15 && a > 5)
               {
                   Console.Write(a + " ");
               }//if
           }// foreach
            Console.WriteLine();

            // q2 d
           var result = (from e in TheList
                        where e > 5 && e < 15
                        orderby e ascending
                        select e).Distinct();
            Console.WriteLine(result.ToPrettyString());
            // q2 e       

            var ascending = (from e in TheList
                            orderby e ascending
                            select e);
            Console.WriteLine(ascending.ToPrettyString());
            
        }

        public static void Question5()
        {
            Console.WriteLine("\nQuestion 5");

            // call the BuildStudentList method which constructs and returns our
            // test list of students and assign to data variable
           var Students = BuildStudentList();

            // q5 a - print the List using our ToPrettyString extension method
            Console.WriteLine(Students.ToPrettyString());

            // q5 b - print students over 20
            var Over20s = Students.Where(s => s.Age > 20);
            Console.WriteLine(Over20s.ToPrettyString());
           
            // q5 c print the names of students over 20 using select projection
            var Over20sNames = Students.Where(s => s.Age > 20)
            .Select(s => s.Name);
            Console.WriteLine(Over20sNames.ToPrettyString());

            // q5 d - print just the Age of Homer - the one student returned
            var Homer = Students.Where(s => s.Name == "Homer")
            .Select(s => s.Age);
            Console.WriteLine($"Homers age is {Homer.ToPrettyString()}");
           
            // alternatively we could use projection to only return an Age (int)
            // rather than a Student 
           
            
            //q5 e - select the name age and Data of students under 20 
            //(custom projection)
            var under20s = Students.Where(s => s.Age < 20)
            .Select(s => new {s.Name, s.Age});
            Console.WriteLine(under20s.ToPrettyString());

            // q5 f - remove students over 20 from data list 
            Students.RemoveAll(s => s.Age > 20);
            Console.WriteLine(Students.ToPrettyString());
        }


        public static void Question6()
        {
            Console.WriteLine("\nQuestion 6");

            // 6a. initialise variable named 'data' using BuildStudentList()
            var data = BuildStudentList();
            
            // 6b. add a new student Id: 5 Name: "Mr Burns", Age: 71 to end of 
            // list
            data.Add(new Student{Id = 5, Name = "Mr Burns", Age = 71});

            // 6c. order the students by age descending
            var ordered = data.OrderByDescending( i => i.Age);

            // 6d. Print Name and Age of ordered results
            foreach(Student student in ordered)
            {
                Console.WriteLine($"Name: {student.Name} \tAge:{student.Age}");
            }// foreach
            

            // 6e.  Print count of number of students who are over 18
           var over18 = data.Count(s => s.Age > 18);
           Console.WriteLine($"The number of adults are {over18}");

            // 6f. Print Age of oldest Student
           var oldest = data.Max(s => s.Age);
           Console.WriteLine($"The oldest student is {oldest}");

        }

    }
}