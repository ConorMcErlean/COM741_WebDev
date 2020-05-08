using System;
using System.ComponentModel.DataAnnotations;

namespace VMS.Data.Models
{
    public class Service
    {     
        // Service Attributes, with CarriedOutBy, Date
        // and Description made required values.

        // Primary Key
        public int ServiceId { get; set;}

        public string CarriedOutBy { get; set;}

        public DateTime DateOfService { get; set;}
    
        public string WorkDescription{ get; set;}

        public int CurrentMilage{ get; set;}

        public double Cost { get; set;}

        // The Related Vehicle for Service Job
        // Each Service job is tied to one Vehicle.
        public int VehicleID { get; set;}
        public Vehicle Vehicle { get; set;}
    }
}