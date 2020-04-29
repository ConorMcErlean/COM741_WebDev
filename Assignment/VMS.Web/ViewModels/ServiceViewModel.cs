using System;
using VMS.Data.Models;

namespace VMS.Web.ViewModels
{
    public class ServiceViewModel
    {
        public string CarriedOutBy { get; set;}
     
        public DateTime DateOfService { get; set;}
       
        public string WorkDescription{ get; set;}
        public int CurrentMilage{ get; set;}
        public double Cost { get; set;}

        public int VehicleID { get; set;}

        public Vehicle Vehicle{get; set;}
    
    }
}