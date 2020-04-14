using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace VMS.Data.Models
{      
    public class Vehicle
    {
        // Primary Key
        public int Id {get; set;}
        [Required]
        public string Make {get; set;}
        [Required]
        public string Model {get; set;}
        public DateTime RegDate {get; set;}
        public string RegNumber {get; set;}
        // Age will set a private variable based on RegDate
        private int _age;
        public int age 
        {   
            get { return _age; }
            set {
                _age = (int) ((DateTime.Now - RegDate).TotalDays)/365;
            }
        }// age
        public string TransmissionType {get; set;}
        [Range(0, 300)]
        public string CO2Rating {get; set;}
        public string FuelType {get; set;}
        public string BodyType {get; set;}
        public string Doors {get; set;}
        public UrlAttribute photo {get; set;}

        IList<Service> Services { get; set;}
    }// Vehicle Class
}