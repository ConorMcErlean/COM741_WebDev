using System;
using System.ComponentModel.DataAnnotations;
using VMS.Data.Models;

namespace VMS.Web.ViewModels
{
    public class ServiceViewModel
    {     
        // Service Attributes, with CarriedOutBy, Date
        // and Description made required values.

        // Primary Key
        public int ServiceId { get; set;}

        [Required]
        public string CarriedOutBy { get; set;}

        [Required]
        public DateTime DateOfService { get; set;}
    
        [Required]
        public string WorkDescription{ get; set;}

        public int CurrentMilage{ get; set;}

        public double Cost { get; set;}

        public int VehicleID { get; set;}
    
        public Service ToService()
        {
            var s = new Service
            {
                ServiceId = this.ServiceId,
                CarriedOutBy = this.CarriedOutBy,
                DateOfService = this.DateOfService,
                WorkDescription = this.WorkDescription,
                CurrentMilage = this.CurrentMilage,
                Cost = this.Cost,
                VehicleID = this.VehicleID
            };
            return s;
        }
    }
}