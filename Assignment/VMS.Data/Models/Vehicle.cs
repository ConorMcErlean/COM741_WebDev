using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace VMS.Data.Models
{      
    public class Vehicle
    {
        // Make, Model, RegDate and Fueltype set as required variables due to
        // them being the key details of purchasing a vehicle.

        // Primary Key
        public int Id {get; set;}

        [Required]
        public string Make {get; set;}

        [Required]
        public string Model {get; set;}

        public string Colour { get; set;}

        [Required]
        [DataType(DataType.Date)]
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

        [Range(0, 300)]
        public int CO2Rating {get; set;}

        [Required]
        public string FuelType {get; set;}

        public string BodyType {get; set;}

        public int Doors {get; set;}

        public string Photo {get; set;}

        // Service List for Vehicle, each Vehicle can have many
        // Services.
        public IList<Service> Services { get; set;}
    }// Vehicle Class
}