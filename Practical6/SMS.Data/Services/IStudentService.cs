using System;
using System.Collections.Generic;

using SMS.Data.Models;

namespace SMS.Data.Services
{
    // This interface describes the operations that a StudentService class should implement
    public interface IStudentService
    {
        // Re-initialise the Database - only to be used during development 
        void Initialise();

        // ---------------- Student Management --------------
        IList<Student> GetAllStudents();
        Student GetStudent(int id);
        Student AddStudent(string name, string email, string course, int age, double grade);
        bool DeleteStudent(int id);
        Student UpdateStudent(int id, Student updated);

        //** New Method ** //
        Student RecalculateStudentGrade(int studentId);     

        // -------------- Module Management -----------------
        Module AddModule(string name);
        StudentModule AddStudentToModule(int studentId, int moduleId);
        bool RemoveStudentFromModule(int studentId, int moduleId);

        /** New Method **/
        StudentModule UpdateStudentModuleMark(int studentId, int moduleId, double mark);

        // -------------- Ticket Management -----------------
        Ticket CreateTicket(int studentId, string issue);
        Ticket CloseTicket(int ticketId);

        IList<Ticket> GetAllTickets();

        IList<Ticket> GetOpenTickets();

    }
    
}
