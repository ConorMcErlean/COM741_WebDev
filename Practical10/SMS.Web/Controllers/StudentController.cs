using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SMS.Web.Models;
using SMS.Data.Models;
using SMS.Data.Services;

namespace SMS.Web.Controllers
{
    public class StudentController : BaseController
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
                Alert("Student Was Not Found", AlertType.danger);
                return RedirectToAction(nameof(Index));
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

            // verify the model s is valid (passes validation rules defined on Student)
            if (ModelState.IsValid)
            {
                // Q2c - complete POST action to add student
                // add student with default grade of 0
                // redirect to the Index Action 
                svc.AddStudent(s.Name,s.Email,s.Course,s.Age,0);
                return RedirectToAction(nameof(Index));
            }
            
            // redisplay the form for editing as there are validation errors
            return View(s);
        }

        // GET /student/edit/{id}
        public IActionResult Edit(int id)
        {
            // Q4b
            // load the student using the service
            var s = svc.GetStudent(id);
            
            // check the returned student is not null and if so return NotFound()
            if (s == null)
            {
                Alert("Student Was Not Found", AlertType.danger);
                return RedirectToAction(nameof(Index));
            }
            
            // pass student to view for editing
            return View( s );
        }

        // POST /student/edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, Student s)
        {
            // Q4c 
            // check model is valid (look at how Create works)
            if (ModelState.IsValid)
            {
            // if valid then call service to update the student and redirecttoaction index
                svc.UpdateStudent(id,s);
                return RedirectToAction(nameof(Index));
            }
            // redisplay the form for editing
            return View(s);
        }

        // GET / student/delete/{id}
        public IActionResult Delete(int id)
        {
            // load student via service         
            var student = svc.GetStudent(id);
            if (student == null)
            {
                Alert("Student Was Not Found", AlertType.danger);
                return RedirectToAction(nameof(Index));
            }
            // pass student to view for deletion confirmation
            return View(student);
        }

        // POST /student/delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            // delete student via service
            svc.DeleteStudent(id);
         
            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }


        // Ticket management

         // GET /student/createticket/{id}
        public IActionResult CreateTicket(int id)
        {
            // retrieve the student identified by id
            var s = svc.GetStudent(id);

            // verify student found and if not return NotFound()
            if (s == null){
                Alert("Student Was Not Found", AlertType.danger);
                return RedirectToAction(nameof(Index));
            }
            // create a ticket view model and set StudentId foreign key to parameter value id
            var tvm = new TicketViewModel{
                StudentId = id
            };
            // render the view passing the viewmodel as a parameter
            return View(tvm);
        }

        // POST /student/create
        [HttpPost]
        public IActionResult CreateTicket(TicketViewModel t)
        {
            // if valid model
            if (ModelState.IsValid){
                //    call service method to create a ticket
                svc.CreateTicket(t.StudentId, t.Issue);
                //    return redirect to display current student
                return RedirectToAction("Details", new{Id =t.StudentId});
                // end
            }
            // redisplay the form for editing passing viewmodel t as a parameter
            return View(t);
        }


    }
}
