using System;

using SMS.Data.Services;
using SMS.Data.Models;

namespace SMS.Data
{
    class Program
    {


        static void Main(string[] args)
        {        
            Console.WriteLine("\n========== Running Tests ==============\n");

            // create the service and initialise to ensure the database is empty
            var svc = new StudentService();
            svc.Initialise();

            // Create some students 
            var s1 = svc.AddStudent("Homer", "Computing",   44, 45.0);
            var s2 = svc.AddStudent("Marge", "Engineering", 40, 68.0);
            var s3 = svc.AddStudent("Bart", "Sleeping",     16, 39.0);
            var s4 = svc.AddStudent("Lisa", "Computing",    13, 86.0);

            // create some modules
            var m1 = svc.AddModule("Programming");
            var m2 = svc.AddModule("Maths");
            var m3 = svc.AddModule("English");

            // Add ticket for Homer    
            var t1 = svc.CreateTicket(s1.Id, "Bart you little ...");

            // Add ticket for Bart
            var t2 = svc.CreateTicket(s3.Id, "Go to Skinners office");

            // Homer is taking programming
            svc.AddStudentToModule(s1.Id, m1.Id);

            // Marge is taking maths
            svc.AddStudentToModule(s2.Id, m2.Id);

            // Bart is taking English 
            svc.AddStudentToModule(s3.Id, m3.Id);

            // Lisa is taking Programming Maths and English
            svc.AddStudentToModule(s4.Id, m1.Id);
            svc.AddStudentToModule(s4.Id, m2.Id);
            svc.AddStudentToModule(s4.Id, m3.Id);


            // Call some service methods to test their operation
            // use the test method defined below to print result of test
      
            // 1. call GetAllStudents and verify it returns 4 students
            Test(svc.GetAllStudents().Count == 4, "GetAllStudents()");

            // 2. call GetStudent to return Homer and verify that he has 1 
            // ticket and his course is Computing
            var homer = svc.GetStudent(s1.Id);
            Test( (homer.ActiveTicketCount == 1) 
                && (homer.Course == "Computing"),"GetStudent()");
        
            // 3. Verify that Lisa is taking 3 modules and has no tickets
            var lisa = svc.GetStudent(s4.Id);
            Test( lisa.StudentModules.Count == 3 && lisa.ActiveTicketCount == 0
                , "GetStudentLisa"
                );

            // 4. Using the CloseTicket service method, close Homers ticket and then verify that its closed
            var t = svc.CloseTicket(t1.Id);
            Test(t.Active == false, "CloseTicket()");
        }

        // Pass boolean expression to test as first parameter and name of test (string)
        // as second parameter. If boolean expression is true then it prints 
        // PASSED test name and if false FAILED: test name 
        // e.g. Test(2 == 2, "Test 2 == 2"); will print PASSED: 2 == 2
        static void Test(bool result, string message)
        {
            if (result == true)
            {
                Console.WriteLine("PASSED: " + message);
            }
            else
            {
                Console.WriteLine("FAILED: " + message);
            }
        }

    }
}
