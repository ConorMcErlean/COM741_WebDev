
using System;
using SMS.Data.Models;

namespace SMS.Data.Services
{
    public static class StudentServiceSeeder
    {
        public static void Seed(IStudentService svc)
        {
            svc.Initialise();

            // Create some students 
            var s1 = svc.AddStudent("Homer", "homer@mail.com", "Computing",   44, 45.0);
            var s2 = svc.AddStudent("Marge", "marge@mail.com", "Engineering", 40, 68.0);
            var s3 = svc.AddStudent("Bart",  "bart@mail.com",  "Sleeping",    16, 39.0);
            var s4 = svc.AddStudent("Lisa",  "lisa@mail.com",  "Computing",   13, 86.0);

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

            // Call service RegisterUser method to add 3 users (one for each role) 
            // admin@sms.com/admin, manager@sms.com/manager, guest@sms.com/guest

        }


    }


}