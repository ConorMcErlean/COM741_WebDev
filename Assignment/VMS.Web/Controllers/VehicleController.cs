using System;

using VMS.Data.Models;
using VMS.Data.Services;
using VMS.Web.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Web.Controllers
{

 public class VehicleController : BaseController
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
            Alert("Vehicle Not Found", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }

        // Get / Vehicle/Create
        public IActionResult Create()
        {
            var vvm = new VehicleViewModel();
            // Render Form
            return View(vvm);
        }

        // Post /Vehicle/Create
        [HttpPost]
        public IActionResult Create(VehicleViewModel vvm)
        {
            if (ModelState.IsValid)
            {
                var v = vvm.ToVehicle();
                svc.AddVehicle(v);
                Alert("Vehicle Created!", AlertType.success);
                return RedirectToAction(nameof(Index));
            }
            return View(vvm);
        }

        // Get /Vehicle/Edit/{Id}
        public IActionResult Edit(int Id){
            var Vehicle = svc.GetVehicleById(Id);
            if (Vehicle != null){
                var vvm = new VehicleViewModel();
                vvm.FromVehicle(Vehicle);
                return View(vvm);
            }
            Alert("Vehicle Not Found", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }

        // Post /Vehicle/Edit/{Id}
        [HttpPost]
        public IActionResult Edit(int id, VehicleViewModel vvm)
        {
            if (ModelState.IsValid)
            {
                var v = vvm.ToVehicle();
                svc.UpdateVehicle(id, v);
                // RedirectToAction("Details", new {id = v.Id});
                Alert("Vehicle Updated", AlertType.success);
                return RedirectToAction(nameof(Index));
            }
            return View(vvm);
        }

        // Get /Vehicle/Delete/{Id}
        public IActionResult Delete(int id)
        {
            var vehicle = svc.GetVehicleById(id);
            if (vehicle == null){
                Alert("Vehicle Not Found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            Alert("Vehicle will Be permanently deleted, are you sure?", 
                AlertType.danger);
            return View(vehicle);
        }

        // Post /Vehicle/Delete
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            svc.DeleteVehicle(id);  
            Alert("Vehicle Deleted.", AlertType.success);
            return RedirectToAction(nameof(Index));
        }

        // Get /Vehicle/AddService/{VehicleID}
        public IActionResult AddService(int VehicleId)
        {
            var svm = new ServiceViewModel{VehicleID = VehicleId};
            // Return Form with ViewModel
            return View(svm);
        }

        // Post /Vehicle/AddService/{VehicleId}
        [HttpPost]
        public IActionResult AddService(ServiceViewModel svm)
        {
            if (ModelState.IsValid)
            {

                /* Convert Service View Model to Service & attach Vehicle */
                var s = svm.ToService();
                s.Vehicle = svc.GetVehicleById(s.VehicleID);
                svc.AddService(s);
                Alert("Service Created", AlertType.success);
                return RedirectToAction("Details", new {id = s.VehicleID});
            }
            return View(svm);
        }

        // Get Vehicle/DeleteService
        public IActionResult DeleteService(int id)
        {
            var Service = svc.GetServiceById(id);
            if (Service == null)
            {
                Alert("Service Not Found", AlertType.warning);
                return RedirectToAction(nameof(Index));
                // Should Be Details
                //return NotFound();
            }
            Alert("Service will be permanently deleted. Are you sure?", 
                AlertType.danger);
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