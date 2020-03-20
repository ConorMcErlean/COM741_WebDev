using System;
using System.Collections.Generic;

using SMS.Data.Models;

namespace SMS.Data.Services
{

    // Define the key business logic interface
    public interface IStudentService 
    {
        // Re-initialise the Database - only to be used during development 
        void Initialise();

        // ---------------- Student Management --------------
        IList<Student> GetAllStudents();
        Student GetStudent(int id);
        Student AddStudent(string name, string course, int age, double grade);       
        bool DeleteStudent(int id);
        Student UpdateStudent(int id, Student updated);

        // -------------- Module Management -----------------
        Module AddModule(string name);
        StudentModule AddStudentToModule(int studentId, int moduleId);
        bool RemoveStudentFromModule(int studentId, int moduleId);

        // -------------- Ticket Management -----------------
        Ticket CreateTicket(int studentId, string issue);
        Ticket CloseTicket(int ticketId);
        IList<Ticket> GetOpenTickets();

    }
}
