using System;

using VMS.Data.Models;
using VMS.Data.Services;
using VMS.Web.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Web.Controllers
{

 public class VehicleController : Controller
    {
        // Service to carry out buisness logic
        private readonly IVehicleService svc;
        public VehicleController()
        {
            svc = new VehicleDbService();
        }// Vehicle Controller

        // Get /Vehicle/Index{order}
        public IActionResult Index(String orderBy)
        {
            // Retrieve list of vehicles
            var VehicleList = svc.GetAllVehicles(orderBy);

            //Render a view with the list
            return View(VehicleList);
        }

        // Get /Vehicle/Details/{id}
        public IActionResult Details(int id)
        {
            // Retrieve required vehicle
            var Vehicle = svc.GetVehicleById(id);

            if (Vehicle != null)
            {
                // Render view with vehicle
                return View(Vehicle);
            }
            return NotFound();
        }

        // Get / Vehicle/Create
        public IActionResult Create()
        {
            // Render Form
            return View();
        }

        // Post /Vehicle/Create
        [HttpPost]
        public IActionResult Create(Vehicle v)
        {
            if (ModelState.IsValid)
            {
                svc.AddVehicle(v);
                return RedirectToAction(nameof(Index));
            }
            return View(v);
        }

        // Get /Vehicle/Edit/{Id}
        public IActionResult Edit(int Id){
            var Vehicle = svc.GetVehicleById(Id);
            if (Vehicle != null){
                return View(Vehicle);
            }
            return NotFound();
        }

        // Post /Vehicle/Edit/{Id}
        [HttpPost]
        public IActionResult Edit(int id, Vehicle v)
        {
            if (ModelState.IsValid)
            {
                svc.UpdateVehicle(id, v);
                // RedirectToAction("Details", new {id = v.Id});
                return RedirectToAction(nameof(Index));
            }
            return View(v);
        }

        // Get /Vehicle/Delete/{Id}
        public IActionResult Delete(int id)
        {
            var vehicle = svc.GetVehicleById(id);
            if (vehicle == null){
                return NotFound();
            }
            return View(vehicle);
        }

        // Post /Vehicle/Delete
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            svc.DeleteVehicle(id);  
            return RedirectToAction(nameof(Index));
        }

        // Get /Vehicle/AddService/{VehicleID}
        public IActionResult AddService(int VehicleId)
        {
            var Vehicle = svc.GetVehicleById(VehicleId);
            if (Vehicle == null){return NotFound();}
            var svm = new ServiceViewModel{VehicleID = Vehicle.Id};
            
            // Return Form with ViewModel
            return View(svm);
        }

        // Post /Vehicle/AddService/{VehicleId}
        [HttpPost]
        public IActionResult AddService(ServiceViewModel svm)
        {
            if (ModelState.IsValid)
            {
                var s = new Service
                {
                    Vehicle = svc.GetVehicleById(svm.VehicleID),
                    VehicleID = svm.VehicleID,
                    CarriedOutBy = svm.CarriedOutBy,
                    DateOfService = svm.DateOfService,
                    CurrentMilage = svm.CurrentMilage,
                    WorkDescription = svm.WorkDescription,
                    Cost = svm.Cost
                };
                svc.AddService(s);
                return RedirectToAction(nameof(Index));
            }
            return View(svm);
        }

        // Get Vehicle/DeleteService
        public IActionResult DeleteService(int id)
        {
            var Service = svc.GetServiceById(id);
            if (Service == null)
            {
                return NotFound();
            }
            return View(Service);
        }

        // Post Vehicle/DeleteServiceConfirm
        [HttpPost]
        public IActionResult DeleteServiceConfirm(int ServiceId)
        {
            svc.DeleteService(ServiceId);
            return RedirectToAction(nameof(Index));
        }
    }// Vehicle Controller

}