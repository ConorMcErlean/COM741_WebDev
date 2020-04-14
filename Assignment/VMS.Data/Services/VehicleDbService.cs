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

        public void Initialise()
        {
            throw new System.NotImplementedException();
        }
       
        // Vehicle Management
        public Vehicle AddVehicle(Vehicle v)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteVehicle(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Vehicle> GetAllVehicles(string orderBy = null)
        {
            throw new System.NotImplementedException();
        }
  
        public Vehicle GetVehicleById(int id)
        {
            throw new System.NotImplementedException();
        }
        public Vehicle UpdateVehicle(int id, Vehicle v)
        {
            throw new System.NotImplementedException();
        }

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