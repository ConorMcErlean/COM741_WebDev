using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using VMS.Data.Models;

namespace VMS.Web.ViewModels
{      
    public class VehicleViewModel
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

        public string TransmissionType {get; set;}

        [Range(0, 300)]
        public int CO2Rating {get; set;}

        [Required]
        public string FuelType {get; set;}

        public string BodyType {get; set;}

        public int Doors {get; set;}
        
        [DataType(DataType.ImageUrl)]
        public string Photo {get; set;}

        public VehicleViewModel()
        {
            // Default Value for View Model
            RegDate = DateTime.Now;
        }
        public void FromVehicle (Vehicle v)
        {
            Id = v.Id;
            Make = v.Make;
            Model = v.Model;
            Colour = v.Colour;
            RegDate = v.RegDate;
            RegNumber = v.RegNumber;
            TransmissionType = v.TransmissionType;
            CO2Rating = v.CO2Rating;
            FuelType = v.FuelType;
            BodyType = v.BodyType;
            Doors = v.Doors;
            Photo = v.Photo;
        }
        public Vehicle ToVehicle()
        {
            var vehicle = new Vehicle
            {
                Make = this.Make,
                Model = this.Model,
                Colour = this.Colour,
                RegDate = this.RegDate,
                RegNumber = this.RegNumber,
                TransmissionType = this.TransmissionType,
                CO2Rating = this.CO2Rating,
                FuelType = this.FuelType,
                BodyType = this.BodyType,
                Doors = this.Doors,
                Photo = this.Photo
            };
            return vehicle;
        }
    }// Vehicle Class
}