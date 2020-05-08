using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace VMS.Data.Models
{      
    public class Vehicle
    {
        public int Id {get; set;}

        public string Make {get; set;}

        public string Model {get; set;}

        public string Colour { get; set;}

        public DateTime RegDate {get; set;}

        public string RegNumber {get; set;}

        // Age will set a private variable based on RegDate
        private int _age;
        public int Age 
        {   
            get { 
                    _age = (int) ((DateTime.Now - RegDate).TotalDays)/365;
                    return _age;
                 }
        }// age

        public string TransmissionType {get; set;}

        public int CO2Rating {get; set;}

        public string FuelType {get; set;}

        public string BodyType {get; set;}

        public int Doors {get; set;}

        public string Photo {get; set;}

        // Service List for Vehicle, each Vehicle can have many
        // Services.
        public IList<Service> Services { get; set;}
    }// Vehicle Class
}