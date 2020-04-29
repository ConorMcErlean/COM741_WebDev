using System;
using System.ComponentModel.DataAnnotations;

namespace VMS.Data.Models
{
    public class Service
    {     
        public int ServiceId { get; set;}
        [Required]
        public string CarriedOutBy { get; set;}
        [Required]
        public DateTime DateOfService { get; set;}
        [Required]
        public string WorkDescription{ get; set;}
        public int CurrentMilage{ get; set;}
        public double Cost { get; set;}

        // The Vehicle Model Work was carried out on
        public int VehicleID { get; set;}
        public Vehicle Vehicle { get; set;}
    }
}