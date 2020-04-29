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
    }// Vehicle Controller

}