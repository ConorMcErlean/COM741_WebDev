using System;
using VMS.Data.Models;

namespace VMS.Data.Services
{
    public static class VehicleServiceSeeder
    {
        // Method to seed a template of data for visualising the project
        public static void Seed(IVehicleService svc)
        {
            svc.Initialise();

            // Create Some Vehicles
            var v1 = new Vehicle
            {
                Make = "Tesla",
                Model = "Model S",
                Colour = "Black",
                RegDate = new DateTime(2012,06,12),
                RegNumber = "AAA 3601",
                TransmissionType = "Automatic",
                CO2Rating = 0,
                FuelType = "Electric",
                BodyType = "Salon",
                Doors = 5,
                Photo = "https://cdn.motor1.com/images/mgl/GMAvV/s4/tesla-model-s-repair.jpg"
            };

            var v2 = new Vehicle
            {
                Make = "Tesla",
                Model = "Model X",
                Colour = "White",
                RegDate = new DateTime(2016,01,16),
                RegNumber = "BBB 3702",
                TransmissionType = "Automatic",
                CO2Rating = 0,
                FuelType = "Electric",
                BodyType = "SUV",
                Doors = 5,
                Photo = "https://cdn.motor1.com/images/mgl/6vqZb/s4/tesla-model-x-by-novitec.jpg"
            };

            var v3 = new Vehicle
            {
                Make = "Tesla",
                Model = "Model 3",
                Colour = "Midnight Blue",
                RegDate = new DateTime(2018,05,18),
                RegNumber = "CCC 3803",
                TransmissionType = "Automatic",
                CO2Rating = 0,
                FuelType = "Electric",
                BodyType = "Salon",
                Doors = 5,
                Photo = "https://cdn.motor1.com/images/mgl/b2xGj/s4/tesla-model-3.jpg"
            };

            var v4 = new Vehicle
            {
                Make = "Tesla",
                Model = "Model Y",
                Colour = "Blue",
                RegDate = new DateTime(2019,07,28),
                RegNumber = "DDD 3904",
                TransmissionType = "Automatic",
                CO2Rating = 0,
                FuelType = "Electric",
                BodyType = "SUV",
                Doors = 5,
                Photo = "https://cdn.motor1.com/images/mgl/GNkWE/s4/tesla-model-y.jpg"
            };

            var v5 = new Vehicle
            {
                Make = "Tesla",
                Model = "Roadster 2020",
                Colour = "Red",
                RegDate = new DateTime(2020,05,17),
                RegNumber = "EEE 4005",
                TransmissionType = "Automatic",
                CO2Rating = 0,
                FuelType = "Electric",
                BodyType = "Sports",
                Doors = 3,
                Photo = "https://cdn.motor1.com/images/mgl/ZZmLr/s4/2020-tesla-roadster.jpg"
            };

            var v6 = new Vehicle
            {
                Make = "Tesla",
                Model = "CyberTruck",
                Colour = "Grey",
                RegDate = new DateTime(2020,05,18),
                RegNumber = "FFF 4106",
                TransmissionType = "Automatic",
                CO2Rating = 0,
                FuelType = "Electric",
                BodyType = "Pick-Up",
                Doors = 4,
                Photo = "https://cdn.motor1.com/images/mgl/XP846/s4/tesla-cybertruck.jpg"
            };

            var v7 = new Vehicle
            {
                Make = "Renault",
                Model = "Zoe",
                Colour = "Blue",
                RegDate = new DateTime(2020,03,16),
                RegNumber = "p4 94230",
                TransmissionType = "Automatic",
                CO2Rating = 0,
                FuelType = "Electric",
                BodyType = "Hatchback",
                Doors = 3,
                Photo = "https://cdn.motor1.com/images/mgl/z2Jn4/s4/renault-zoe-2020.jpg"
            };

            // Add to DB
            svc.AddVehicle(v1);
            svc.AddVehicle(v2);
            svc.AddVehicle(v3);
            svc.AddVehicle(v4);
            svc.AddVehicle(v5);
            svc.AddVehicle(v6);
            svc.AddVehicle(v7);

            // Create some Services
            var s1 = new Service
            {
                CarriedOutBy = "Elon Musk",
                DateOfService = new DateTime (2018,12,12),
                WorkDescription = "Updating the autopilot to level 3",
                CurrentMilage = 2500,
                Cost = 3000,
                VehicleID = v1.Id
            };

               var s2 = new Service
            {
                CarriedOutBy = "Elon Musk",
                DateOfService = new DateTime (2017,01,25),
                WorkDescription = "Making car sing and dance to christmas music",
                CurrentMilage = 3000,
                Cost = 00.00,
                VehicleID = v2.Id
            };

               var s3 = new Service
            {
                CarriedOutBy = "Elon Musk",
                DateOfService = new DateTime (2019,09,27),
                WorkDescription = "Adding videogames to infotainment system",
                CurrentMilage = 1000,
                Cost = 1000,
                VehicleID = v3.Id
            };

               var s4 = new Service
            {
                CarriedOutBy = "Joe Bloggs",
                DateOfService = new DateTime (2019,12,12),
                WorkDescription = "Replacing Cracked window after demonstrating the bulletproof glass",
                CurrentMilage = 00,
                Cost = 2500,
                VehicleID = v6.Id
            };

            // Add to DB
        }
    }
}// Namespace