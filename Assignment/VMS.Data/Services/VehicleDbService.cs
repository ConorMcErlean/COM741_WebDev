using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using VMS.Data.Models;
using VMS.Data.Repositories;

namespace VMS.Data.Services
{
    // implement each of these methods (removing the thow statements)
    public class VehicleDbService : IVehicleService
    {
        private readonly VehicleDbContext db;
    
        public VehicleDbService()
        {
            db = new VehicleDbContext();
        }

        public void Initialise()
        {
            db.Initialise();
        }
       
        // Vehicle Management
        public Vehicle AddVehicle(Vehicle v)
        {
            // Verify Same Vehicle does not exist (using RegNum as a unique Attribute)
            var Previous = db.Vehicles.FirstOrDefault( p => p.RegNumber == v.RegNumber);
            if (Previous != null){ return null; }
            // If not add Vehicle
            db.Vehicles.Add(v);
            db.SaveChanges();
            // Return added vehicle
            return v;
        } // AddVehicle

        public bool DeleteVehicle(int id)
        {
            // Select Vehicle to be removed
            var ToBeRemoved = db.Vehicles.FirstOrDefault(v => v.Id == id);

            // Check if vehicle exists if not return false
            if (ToBeRemoved == null){ return false; }

            // Remove Vehicle
            db.Vehicles.Remove(ToBeRemoved);

            // Save and return true
            db.SaveChanges();
            return true;

        }// DeleteVehicle

        public IList<Vehicle> GetAllVehicles(string orderBy = null)
        {
            // Based on OrderBy Query Database 
            switch(orderBy)
            {
                case "make": 
                    return db.Vehicles.Include(v => v.Services).OrderBy(v => v.Make).ToList();
                case "fuel": 
                    return db.Vehicles.Include(v => v.Services).OrderBy(v => v.FuelType).ToList();
                case "registered": 
                    return db.Vehicles.Include(v => v.Services).OrderBy(v => v.RegDate).ToList();
                default:
                    return db.Vehicles.Include(v => v.Services).ToList();
                    
            } // Switch  
        }// GetAllVehicles
  
        public Vehicle GetVehicleById(int id)
        {
            return db.Vehicles.Include(v => v.Services).FirstOrDefault(v => v.Id == id);
        }// GetVehicleById
        public Vehicle UpdateVehicle(int id, Vehicle v)
        {
            // Find Vehicle matching ID
            var Previous = db.Vehicles.FirstOrDefault( v => v.Id == id);

            // Check it exists (if not return null)
            if (Previous == null){
                return null;
            }

            // Set Vehicle Attributes
            // Previous = v; // Set all in one go: Did not work correctly

            Previous.Make = v.Make;
            Previous.Model = v.Model;
            Previous.Colour =v.Colour;
            Previous.RegDate =v.RegDate;
            Previous.RegNumber =v.RegNumber;
            Previous.TransmissionType =v.TransmissionType;
            Previous.CO2Rating =v.CO2Rating;
            Previous.FuelType =v.FuelType;
            Previous.BodyType =v.BodyType;
            Previous.Doors =v.Doors;
            Previous.Photo =v.Photo;

            //Save & Return
            db.SaveChanges();
            return Previous;

        }// UpdateVehicle

        // Service Management
        public Service AddService(Service s)
        {
            // Check if service exists (Using date, vehicle & cost) if so return null
            var Previous = db.Services.FirstOrDefault( p => (p.DateOfService == s.DateOfService) && 
                                                            (p.Vehicle == s.Vehicle) &&
                                                            (p.Cost == s.Cost) );
            if (Previous != null){ return null;}

            // Check if Vehicle exists, if not return null
            var vehicle = db.Vehicles.FirstOrDefault( v => s.Vehicle.Id == v.Id);
            if (vehicle == null){ return null;}
            // Add service
            db.Services.Add(s);

            // Save and return
            db.SaveChanges();
            return s;
        } // AddService
        public Service GetServiceById(int id)
        {
            return db.Services.Include(s => s.Vehicle).FirstOrDefault( s => s.ServiceId == id);
        } // GetServiceById
        public bool DeleteService(int id)
        {
            // Check Service Exists
            var ToBeRemoved = db.Services.FirstOrDefault( s => s.ServiceId == id);
            if (ToBeRemoved == null){ return false; }

            // If so Delete & Return true
            db.Services.Remove(ToBeRemoved);
            db.SaveChanges();
            return true;
        }
    } // VehicleDbService
}