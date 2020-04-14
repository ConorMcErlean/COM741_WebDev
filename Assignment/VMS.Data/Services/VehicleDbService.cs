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
            db.Add(v);
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
            Previous = v;

            //Save & Return
            db.SaveChanges();
            return Previous;

        }// UpdateVehicle

        // Service Management
        public Service AddService(Service s)
        {
            throw new System.NotImplementedException();
        }
        public Service GetServiceById(int id)
        {
            throw new System.NotImplementedException();
        }
        public bool DeleteService(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}