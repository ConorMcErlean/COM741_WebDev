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
        public TestVehicleService()
        {
            // General Arangement
            svc = new VehicleDbService();
            // Ensure clean slate Database
            svc.Initialise();
        }
        
       // define a set of appropriate tests to test the vehicle service class

       // AddVehicle Tests
       [Fact]
       public void AddVehicle_WhenNone_ShouldNotReturnNull()
       {
       //Given
       var car = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
       
       //When
       var v = svc.AddVehicle(car);
       
       //Then
       Assert.NotNull(v);
       }
 
        [Fact]
        public void AddVehicle_WhenNone_ShouldSetAllAttributes()
        {
        //Given
        var v1 = new Vehicle {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
        };
        
        //When
        var v2 = svc.AddVehicle(v1);
        var v3 = svc.GetVehicleById(v1.Id);
        
        //Then
        Assert.NotNull(v2);
        Assert.Equal(v1, v2);

        Assert.Equal(v1.Id, v3.Id);
        Assert.Equal(v1.Model, v3.Model);
        Assert.Equal(v1.Colour, v3.Colour);
        Assert.Equal(v1.RegDate, v3.RegDate);
        Assert.Equal(v1.Age, v3.Age);
        Assert.Equal(v1.RegNumber, v3.RegNumber);
        Assert.Equal(v1.TransmissionType, v3.TransmissionType);
        Assert.Equal(v1.CO2Rating, v3.CO2Rating);   
        Assert.Equal(v1.FuelType, v3.FuelType);
        Assert.Equal(v1.BodyType, v3.BodyType);
        Assert.Equal(v1.Doors, v3.Doors);
        Assert.Equal(v1.Photo, v3.Photo);
        }
        
        [Fact]
        public void AddVehicle_WhenDuplicate_ShouldReturnNull()
        {
        //Given
        var v1 = new Vehicle {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
        };
        
        //When
        var v2 = svc.AddVehicle(v1);
        var v3 = svc.AddVehicle(v1);
        
        //Then
        Assert.NotNull(v1);
        Assert.NotNull(v2);
        Assert.Null(v3);
        }

        [Fact]
        public void AddVehicle_WhenDifferentExists_ShouldSetAttributes()
        {
        //Given
        var v1 = new Vehicle {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
        };
        var v2 = new Vehicle {
            Make = "III",
            Model = "JJJ",
            Colour = "KKK",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "LLL",
            TransmissionType = "MMM",
            CO2Rating = 1,
            FuelType = "NNN",
            BodyType = "OOO",
            Doors = 2,
            Photo = "PPP"
        };
        
        //When
        var v3 = svc.AddVehicle(v1);
        var v4 =svc.AddVehicle(v2);
        
        //Then
        Assert.NotNull(v1);
        Assert.NotNull(v2);
        Assert.NotNull(v3);
        Assert.NotNull(v4);
        Assert.Equal(v1, v3);
        Assert.Equal(v2, v4);

        }
        
        // DeleteVehicle Tests
        [Fact]
        public void DeleteVehicle_WhenVehicleDoesntExist_ShouldReturnFalse()
        {
        //Given
        
        //When
        var d1 = svc.DeleteVehicle(001);
        
        //Then
        Assert.False(d1);
        }

        [Fact]
        public void DeleteVehicle_WhenDoesExist_ShouldReturnTrue()
        {
        //Given
        var v1 = new Vehicle {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
        };
        v1 = svc.AddVehicle(v1);
        
        //When
        var d1 = svc.DeleteVehicle(v1.Id);
        
        //Then
        Assert.True(d1);
        }

        [Fact]
        public void DeleteVehicle_WhenDoesExist_ShouldRemove()
        {
        //Given
        var v1 = new Vehicle {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
        };
        v1 = svc.AddVehicle(v1);

        //When
        var d1 = svc.DeleteVehicle(v1.Id);
        var d2 = svc.GetVehicleById(v1.Id);

        //Then
        Assert.Null(d2);
        }

    // GetAllVehicles Tests

    [Fact]
    public void GetAllVehicle_WhenNoVehicles_ShouldReturnEmpty()
    {
    //Given
    
    //When
    var list = svc.GetAllVehicles();
    
    //Then
    Assert.Empty(list);
    }

    [Fact]
    public void GetAllVehicle_WhenVehicles_ShouldReturnList()
    {
    //Given
    var v1 = new Vehicle {
            Make = "AAA",
            Model = "ZZZ",
            RegDate = new DateTime(02/02/2002),
            RegNumber = "ABC",
            FuelType = "VVV"
        };
    svc.AddVehicle(v1);

    var v2 = new Vehicle {
            Make = "BBB",
            Model = "YYY",
            RegDate = new DateTime(01/01/2001),
            RegNumber = "DEF",
            FuelType = "VVV"
        };
    svc.AddVehicle(v2);

    var v3 = new Vehicle {
            Make = "CCC",
            Model = "XXX",
            RegDate = new DateTime(03/03/2003),
            RegNumber = "GHI",
            FuelType = "VVV"
        };
    svc.AddVehicle(v3);
    
    //When
    var list = svc.GetAllVehicles();
    
    //Then
    Assert.NotEmpty(list);
    Assert.Equal(list[0], v1);
    Assert.Equal(list[1], v2);
    Assert.Equal(list[2], v3);
    }

    [Fact]
    public void GetAllVehicle_WhenVehicles_ParameterMake_ShouldReturnListOrderedByMake()
    {
    //Given
    var v1 = new Vehicle {
            Make = "AAA",
            Model = "ZZZ",
            RegDate = new DateTime(02/02/2002),
            RegNumber = "ABC",
            FuelType = "VVV"
        };
    svc.AddVehicle(v1);

    var v2 = new Vehicle {
            Make = "BBB",
            Model = "YYY",
            RegDate = new DateTime(01/01/2001),
            RegNumber = "DEF",
            FuelType = "VVV"
        };
    svc.AddVehicle(v2);

    var v3 = new Vehicle {
            Make = "CCC",
            Model = "XXX",
            RegDate = new DateTime(03/03/2003),
            RegNumber = "GHI",
            FuelType = "VVV"
        };
    svc.AddVehicle(v3);
    
    //When
    var list = svc.GetAllVehicles("Make");
    
    //Then
    Assert.NotEmpty(list);
    Assert.Equal(list[0], v1);
    Assert.Equal(list[1], v2);
    Assert.Equal(list[2], v3);
    }

    [Fact]
    public void GetAllVehicle_WhenVehicles_ParameterModel_ShouldReturnListOrderedByModel()
    {
    //Given
    var v1 = new Vehicle {
            Make = "AAA",
            Model = "ZZZ",
            RegDate = new DateTime(02/02/2002),
            RegNumber = "ABC",
            FuelType = "VVV"
        };
    svc.AddVehicle(v1);

    var v2 = new Vehicle {
            Make = "BBB",
            Model = "YYY",
            RegDate = new DateTime(01/01/2001),
            RegNumber = "DEF",
            FuelType = "VVV"
        };
    svc.AddVehicle(v2);

    var v3 = new Vehicle {
            Make = "CCC",
            Model = "XXX",
            RegDate = new DateTime(03/03/2003),
            RegNumber = "GHI",
            FuelType = "VVV"
        };
    svc.AddVehicle(v3);
    
    //When
    var list = svc.GetAllVehicles("Model");
    
    //Then
    Assert.NotEmpty(list);
    Assert.Equal(list[0], v3);
    Assert.Equal(list[1], v2);
    Assert.Equal(list[2], v1);
    }

    [Fact]
    public void GetAllVehicle_WhenVehicles_ParameterRegDate_ShouldReturnListOrderedByRegDate()
    {
    //Given
    var v1 = new Vehicle {
            Make = "AAA",
            Model = "ZZZ",
            RegDate = new DateTime(2002,02,02),
            RegNumber = "ABC",
            FuelType = "VVV"
        };
    svc.AddVehicle(v1);

    var v2 = new Vehicle {
            Make = "BBB",
            Model = "YYY",
            RegDate = new DateTime(2001,01,01),
            RegNumber = "DEF",
            FuelType = "VVV"
        };
    svc.AddVehicle(v2);

    var v3 = new Vehicle {
            Make = "CCC",
            Model = "XXX",
            RegDate = new DateTime(2003,03,03),
            RegNumber = "GHI",
            FuelType = "VVV"
        };
    svc.AddVehicle(v3);
    
    //When
    var list = svc.GetAllVehicles("RegDate");
    
    //Then
    Assert.NotEmpty(list);
    Assert.Equal(list[0], v2);
    Assert.Equal(list[1], v1);
    Assert.Equal(list[2], v3);
    }

    [Fact]
    public void GetAllVehicle_WhenVehicles_ParameterFuelType_ShouldReturnListOrderedByFuelType()
    {
    //Given
    var v1 = new Vehicle {
            Make = "AAA",
            Model = "ZZZ",
            RegDate = new DateTime(02/02/2002),
            FuelType= "Diesel",
            RegNumber = "ABC"
        };
    svc.AddVehicle(v1);

    var v2 = new Vehicle {
            Make = "BBB",
            Model = "YYY",
            RegDate = new DateTime(01/01/2001),
            FuelType = "Petrol",
            RegNumber = "DEF"
        };
    svc.AddVehicle(v2);

    var v3 = new Vehicle {
            Make = "CCC",
            Model = "XXX",
            RegDate = new DateTime(03/03/2003),
            FuelType = "Electric",
            RegNumber = "GHI"
        };
    svc.AddVehicle(v3);
    
    //When
    var list = svc.GetAllVehicles("FuelType");
    
    //Then
    Assert.NotEmpty(list);
    Assert.Equal(list[0], v1);
    Assert.Equal(list[1], v3);
    Assert.Equal(list[2], v2);
    }
    // GetVehicleById Tests

    [Fact]
    public void GetVehicleById_WhenExists_ShouldReturnVehicle()
    {
    //Given
    var car = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    var added = svc.AddVehicle(car);
    
    //When
    var selected = svc.GetVehicleById(car.Id);
    
    //Then
    Assert.NotNull(selected);
    Assert.Equal(added, selected);
    }

    [Fact]
    public void GetVehicleById_WhenMultipleExist_ShouldReturnVehicle()
    {
    //Given
    var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    var v2 = new Vehicle {
        Make = "III",
        Model = "JJJ",
        Colour = "KKK",
        RegDate = new DateTime(01/01/2011),
        RegNumber = "LLL",
        TransmissionType = "MMM",
        CO2Rating = 1,
        FuelType = "NNN",
        BodyType = "OOO",
        Doors = 2,
        Photo = "PPP"
    };
        v1 = svc.AddVehicle(v1);
        v2 = svc.AddVehicle(v2);
    
    //When
    var s1 = svc.GetVehicleById(v1.Id);
    var s2 = svc.GetVehicleById(v2.Id);
    
    //Then
    Assert.NotNull(s1);
    Assert.NotNull(s2);
    Assert.Equal(v1, s1);
    Assert.Equal(v2, s2);
    }
    
    [Fact]
    public void GetVehicleById_WhenDoesntExist_ShouldReturnNull()
    {
    //Given
    var v1 = new Vehicle {
            Make = "III",
            Model = "JJJ",
            Colour = "KKK",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "LLL",
            TransmissionType = "MMM",
            CO2Rating = 1,
            FuelType = "NNN",
            BodyType = "OOO",
            Doors = 2,
            Photo = "PPP"
        };
    
    //When
    var s1 = svc.GetVehicleById(v1.Id);
    
    //Then
    Assert.Null(s1);
    }
    
    // UpdateVehicle Tests
    [Fact]
    public void UpdateVehicle_WhenDoesntExist_ShouldReturnNull()
    {
    //Given
    var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    
    //When
    var edited = svc.UpdateVehicle(001, v1);
    
    //Then
    Assert.Null(edited);
    }

    [Fact]
    public void UpdateVehicle_WhenExists_ShouldModifyAtttributes()
    {
    //Given
    var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    v1 = svc.AddVehicle(v1);
    var v1Modified = new Vehicle
       {
            Make = "AAAA",
            Model = "BBBB",
            Colour = "CCCC",
            RegDate = new DateTime(02/02/2011),
            RegNumber = "DDDD",
            TransmissionType = "EEEE",
            CO2Rating = 11,
            FuelType = "FFFF",
            BodyType = "GGGG",
            Doors = 22,
            Photo = "HHHH"
       };
    
    //When
    var edited = svc.UpdateVehicle(v1.Id, v1Modified);
    var selected =svc.GetVehicleById(v1.Id);
    
    //Then
    Assert.NotNull(edited);

    // Check Attributes Returned by method and retrieved from DB
    Assert.Equal(v1Modified.Make, edited.Make);
    Assert.Equal(v1Modified.Make, selected.Make);

    Assert.Equal(v1Modified.Model, edited.Model);
    Assert.Equal(v1Modified.Model, selected.Model);

    Assert.Equal(v1Modified.RegDate, edited.RegDate);
    Assert.Equal(v1Modified.RegDate, selected.RegDate);

    Assert.Equal(v1Modified.Make, edited.Make);
    Assert.Equal(v1Modified.Make, selected.Make);

    Assert.Equal(v1Modified.RegNumber, edited.RegNumber);
    Assert.Equal(v1Modified.RegNumber, selected.RegNumber);

    Assert.Equal(v1Modified.Age, edited.Age);
    Assert.Equal(v1Modified.Age, selected.Age);

    Assert.Equal(v1Modified.TransmissionType, edited.TransmissionType);
    Assert.Equal(v1Modified.TransmissionType, selected.TransmissionType);

    Assert.Equal(v1Modified.CO2Rating, edited.CO2Rating);
    Assert.Equal(v1Modified.CO2Rating, selected.CO2Rating);

    Assert.Equal(v1Modified.FuelType, edited.FuelType);
    Assert.Equal(v1Modified.FuelType, selected.FuelType);

    Assert.Equal(v1Modified.BodyType, edited.BodyType);
    Assert.Equal(v1Modified.BodyType, selected.BodyType);

    Assert.Equal(v1Modified.Doors, edited.Doors);
    Assert.Equal(v1Modified.Doors, selected.Doors);

    Assert.Equal(v1Modified.Photo, edited.Photo);
    Assert.Equal(v1Modified.Photo, selected.Photo);
    }
    
    // AddService Tests
    [Fact]
    public void AddService_WhenVehicleDoesntExist_ShouldReturnNull()
    {
    //Given
    var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    
    var s1 = new Service
    {
        CarriedOutBy = "AAA",
        DateOfService = new DateTime(12/12/2012),
        WorkDescription = "BBB",
        CurrentMilage = 1,
        Cost = 1.0,
        Vehicle = v1
    };
    
    //When
    var added = svc.AddService(s1);
    
    //Then
    Assert.Null(added);
    }
    [Fact]
    public void AddService_WhenVehicleDoesExist_ShouldReturnService()
    {
    //Given
    var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    svc.AddVehicle(v1);
    var s1 = new Service
    {
        CarriedOutBy = "AAA",
        DateOfService = new DateTime(12/12/2012),
        WorkDescription = "BBB",
        CurrentMilage = 1,
        Cost = 1.0,
        Vehicle = v1
    };
    
    //When
    var added = svc.AddService(s1);
    
    //Then
    Assert.NotNull(added);
    Assert.Equal(s1, added);
    }
    
    [Fact]
    public void AddService_WhenServiceExists_ShouldReturnNull()
    {
    //Given
    var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    svc.AddVehicle(v1);
    var s1 = new Service
    {
        CarriedOutBy = "AAA",
        DateOfService = new DateTime(12/12/2012),
        WorkDescription = "BBB",
        CurrentMilage = 1,
        Cost = 1.0,
        Vehicle = v1
    };
    var s2 = new Service
    {
        CarriedOutBy = "AAA",
        DateOfService = new DateTime(12/12/2012),
        WorkDescription = "BBB",
        CurrentMilage = 1,
        Cost = 1.0,
        Vehicle = v1
    };
    
    //When
    svc.AddService(s1);
    var Added = svc.AddService(s2);
    //Then
    Assert.Null(Added);
    }
    
    // GetServiceById Tests

    [Fact]
    public void GetServiceById_WhenNoService_ShouldReturnNull()
    {
    //Given
    
    //When
    var selected = svc.GetServiceById(001);
    
    //Then
    Assert.Null(selected);
    }

    [Fact]
    public void GetServiceById_WhenServiceExists_ShouldReturnService()
    {
    //Given
    
     var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    svc.AddVehicle(v1);
    var s1 = new Service
    {
        CarriedOutBy = "AAA",
        DateOfService = new DateTime(12/12/2012),
        WorkDescription = "BBB",
        CurrentMilage = 1,
        Cost = 1.0,
        Vehicle = v1
    };
    svc.AddService(s1);

    //When
    var selected = svc.GetServiceById(s1.ServiceId);
    
    //Then
    Assert.NotNull(selected);
    Assert.Equal(s1, selected);

    }

    [Fact]
    public void GetServiceByVehicle_WhenServiceExists_ShouldReturnService()
    {
    //Given
    
     var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    svc.AddVehicle(v1);
    var s1 = new Service
    {
        CarriedOutBy = "AAA",
        DateOfService = new DateTime(12/12/2012),
        WorkDescription = "BBB",
        CurrentMilage = 1,
        Cost = 1.0,
        Vehicle = v1
    };
    svc.AddService(s1);

    //When
    var selected = svc.GetVehicleById(v1.Id);
    var service = selected.Services[0];
    
    //Then
    Assert.NotNull(service);
    Assert.Equal(s1, service);

    }

    // DeleteService Tests
    [Fact]
    public void DeleteService_WhenServiceDoesntExist_ShouldReturnFalse()
    {
    //Given
    
    //When
    var deleted = svc.DeleteService(001);
    
    //Then
    Assert.False(deleted);
    }

    

    [Fact]
    public void DeleteService_WhenServiceExists_ShouldReturnTrue()
    {
    //Given
     var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    svc.AddVehicle(v1);
    var s1 = new Service
    {
        CarriedOutBy = "AAA",
        DateOfService = new DateTime(12/12/2012),
        WorkDescription = "BBB",
        CurrentMilage = 1,
        Cost = 1.0,
        Vehicle = v1
    };
    svc.AddService(s1);
    
    //When
    var deleted = svc.DeleteService(s1.ServiceId);
    
    //Then
    Assert.True(deleted);

    }

    [Fact]
    public void DeleteService_WhenServiceExists_ShouldRemoveService()
    {
    //Given
     var v1 = new Vehicle
       {
            Make = "AAA",
            Model = "BBB",
            Colour = "CCC",
            RegDate = new DateTime(01/01/2011),
            RegNumber = "DDD",
            TransmissionType = "EEE",
            CO2Rating = 1,
            FuelType = "FFF",
            BodyType = "GGG",
            Doors = 2,
            Photo = "HHH"
       };
    svc.AddVehicle(v1);
    var s1 = new Service
    {
        CarriedOutBy = "AAA",
        DateOfService = new DateTime(12/12/2012),
        WorkDescription = "BBB",
        CurrentMilage = 1,
        Cost = 1.0,
        Vehicle = v1
    };
    svc.AddService(s1);
    
    //When
    var deleted = svc.DeleteService(s1.ServiceId);
    var retrieved = svc.GetServiceById(s1.ServiceId);
    
    //Then
    Assert.Null(retrieved);
    
    }

    } // TestVehicleService

} // Namespace