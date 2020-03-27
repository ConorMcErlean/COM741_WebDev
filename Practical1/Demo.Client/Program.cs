using System;
using Demo.Client.Data;


namespace Demo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1();
            
    
            

          
           //Question3();
           
            Question5();
           // Question6();
        }

        static void Question1()
        {
            int studentId = 007;
            string name = "Conor";
            string course = "Professional Software Programming";
            DateTime dateOfBirth = new DateTime(1996, 01, 25);
            int age = (DateTime.Now - dateOfBirth).Days/365;

            // Printing
            Console.WriteLine($"ID:{studentId} Name:{name} "+
            $"Course:{course} DOB:{dateOfBirth.ToShortDateString()} Age:{age}");
        }

        static void Question3()
        {
            var Student1 = new Student();
            Student1.Name = "Homer";
            Student1.Course = "Law";
            Student1.Dob = new DateTime(1998, 06, 30);
            var Student2 = new Student{Name = "Marge", Course = "Psychology", Id = 001, 
            Dob = new DateTime(2000, 01, 04)};
    
            // Prints
            Console.WriteLine(Student1);
            Console.WriteLine(Student2);
        }

        static void Question5()
        {
            // here we prompt the user to input values to construct a student
            // we use to custom methods to read an integer and read a string defined below
            // both print a prompt which is passed as a parameter

            var s = new Student();
            s.Id = ReadInteger("Enter ID: ");
            s.Name = ReadString("Enter Name: ");

            var year = ReadInteger("Enter year");
            var month = ReadInteger("Enter month");
            var day = ReadInteger("Enter day");

            s.Dob = new DateTime(year, month, day);

            Console.WriteLine(s);
     
        }

        static void Question6()
        {
       
        }


        static int ReadInteger(string prompt)
        {
            do {
                Console.Write(prompt);
                var str = Console.ReadLine();
                try {
                    return Convert.ToInt32(str);
                } catch (FormatException) {
                    Console.WriteLine($"Invalid: {str}");
                }
            } while(true);
        }   

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        } 

    }
}
