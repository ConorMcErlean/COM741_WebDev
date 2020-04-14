using System;
using Xunit;

// importing dependencies from the Data Project
using VMS.Data.Models;
using VMS.Data.Services;

namespace VMS.Test
{
    
    public class TestVehicleService
    {
        // Service
        private readonly IVehicleService svc;
        private TestVehicleService()
        {
            // General Arangement
            svc = new VehicleDbService;
            // Ensure clean slate Database
            svc.Initialise();
        }
        
       // define a set of appropriate tests to test the vehicle service class
       [Fact]
       public void AddVehicle_WhenNone_ShouldNotReturnNull()
       {
       //Given
       var car = new Vehicle();
       
       //When
       var v = svc.AddVehicle(car);
       
       //Then
       Assert.NotNull(v);
       }
 
    }
}