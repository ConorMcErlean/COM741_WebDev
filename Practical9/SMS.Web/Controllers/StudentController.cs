using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMS.Web.Models;
using SMS.Data.Models;
using SMS.Data.Services;

namespace SMS.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService svc;
        public StudentController()
        {
            svc = new StudentService();
        }

        // GET /student/index
        public IActionResult Index()
        {
            var students = svc.GetAllStudents();
            return View(students);
        }

        // GET /student/details/{id}
        public IActionResult Details(int id)
        {
            var student = svc.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET /student/create
        public IActionResult Create()
        {
            // render blank form
            return View();
        }

        // POST /student/create
        [HttpPost]
        public IActionResult Create(Student s)
        {
            // Q2c - complete POST action to add student
            // if model is valid 
            if (ModelState.IsValid)
            {
                //    pass data to service to store
                var saved = svc.AddStudent(s.Name, s.Email, s.Course, s.Age, s.Profile.Grade);
                // Redirect to index URL
                return RedirectToAction(nameof(Details), new {Id = saved.Id});
                // end
            }
            // redisplay the form for editing as there are validation errors
            return View(s);
        }

        // GET /student/edit/{id}
        public IActionResult Edit(int id)
        {
            // Q4b
            // load the student using the service
            var student = svc.GetStudent(id);
            // check the returned student is not null and if so return NotFound()
            if (student == null)
            {return NotFound();}
            // pass student to view for editing
            return View(student);
        }

        // POST /student/edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, Student s)
        {
            // Q4c 
            // if check model is valid (look at how Create works)
            if (ModelState.IsValid)
            {
                //    update student via service
                svc.UpdateStudent(id, s);
                return RedirectToAction(nameof(Index));
                // end
            }   
            // redisplay the form for editing as validation errors
            return View(s);
        }

        // GET / student/delete/{id}
        public IActionResult Delete(int id)
        {
            // Q5b
            // load student via service  
            var byebye = svc.GetStudent(id);

            // check student not null and if so return NotFound()   
            if (byebye == null)
            {return NotFound();}    
            
            // pass student to view for deletion confirmation
            return View(byebye);
        }

        // POST /student/delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            //Q5c
            // delete student via service
            var result = svc.DeleteStudent(id);
         
            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }

    }
}
