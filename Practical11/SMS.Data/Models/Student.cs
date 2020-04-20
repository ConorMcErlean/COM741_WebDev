
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    // Class representing a table in our database
    public class Student
    {
        public Student()
        {
            // initialise the Tickets relationship
            Tickets = new List<Ticket>();

            // intialise the StudentModules relationship
            StudentModules = new List<StudentModule>();

            // initialise the profile - we want student created with a profile
            Profile = new Profile { Grade = 0.0 };
        }
        // primary key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Course { get; set; }
        [Range(16,80)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        // Read-only property returning count of active tickets 
        public int ActiveTicketCount => Tickets.Where(t => t.Active).Count();

        // Navigation properties 
        public Profile Profile { get; set; }
        public ICollection<Ticket> Tickets {get; set;}
        public ICollection<StudentModule> StudentModules {get; set;}

        // Used for printing Students to the console during testing
        public override string ToString()
        {
            return $"Id:{Id} Name:{Name} Course:{Course} Age:{Age} Email: {Email} Grade: {Profile.Grade} ";
        }
    }
}