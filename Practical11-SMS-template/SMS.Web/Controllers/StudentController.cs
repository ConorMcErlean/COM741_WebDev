using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMS.Web.Models;
using SMS.Data.Models;
using SMS.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            // render blank form
            return View();
        }

        // POST /student/create
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name, Email, Course, Age")] Student s)
        {
            // verify the model s is valid (passes validation rules defined on Student)
            if (ModelState.IsValid)
            {
                svc.AddStudent(s.Name,s.Email,s.Course,s.Age,0);
                Alert("Student created successfully",AlertType.success);
                return RedirectToAction(nameof(Index));
            }
            
            // redisplay the form for editing as there are validation errors
            return View(s);
        }

        // GET /student/edit/{id}
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(int id)
        {
            // load the student using the service
            var s = svc.GetStudent(id);
            
            // check the returned student is not null 
            if (s == null)
            {
                Alert("Student Not Found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            
            // pass student to view for editing
            return View( s );
        }

        // POST /student/edit/{id}
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name, Email, Course, Age")] Student s)
        {
            // check model is valid 
            if (ModelState.IsValid)
            {
                // if valid then call service to update the student and redirecttoaction index
                svc.UpdateStudent(id,s);
                Alert("Student updated successfully", AlertType.success);
                return RedirectToAction(nameof(Index));
            }
            // redisplay the form for editing
            return View(s);
        }

        // GET / student/delete/{id}
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            // load student via service         
            var student = svc.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            // pass student to view for deletion confirmation
            return View(student);
        }

        // POST /student/delete/{id}
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            // delete student via service
            svc.DeleteStudent(id);
            Alert("Student deleted successfully", AlertType.success);
         
            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }


        // ---------- Ticket management ----------------

        // GET /student/createticket/{id}
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateTicket(int id)
        {
            var s = svc.GetStudent(id);
            if (s == null)
            {
                Alert("Student Not Found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            // create a ticket view model and set foreign key
            var tvm = new TicketViewModel { StudentId = id }; 
            // render blank form
            return View( tvm );
        }

        // POST /student/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateTicket([Bind("StudentId, Issue")] TicketViewModel t)
        {
            if (ModelState.IsValid)
            {                
                svc.CreateTicket(t.StudentId, t.Issue);

                return RedirectToAction(nameof(Details), new { Id = t.StudentId });
            }
            // redisplay the form for editing
            return View(t);
        }

        // ----------- Module Management -------------------------------

        // GET /student/updatemodule/{id}
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult UpdateModule(int id)
        {
            var sm = svc.GetStudentModule(id);  
            if (sm == null)
            {
                Alert("Student Module Not Found", AlertType.warning);
                return RedirectToAction(nameof(Details));
            }
            var vm = new StudentModuleViewModel {
                StudentId = sm.StudentId,
                ModuleId = sm.ModuleId,
                Mark = sm.Mark
            };            
            return View( vm );
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateModule([Bind("StudentId, ModuleId, Mark")] StudentModuleViewModel sm)
        {
            if (ModelState.IsValid)
            {                
                svc.UpdateStudentModuleMark(sm.StudentId, sm.ModuleId, sm.Mark);

                return RedirectToAction(nameof(Details), new { Id = sm.StudentId });
            }
            // redisplay the form for editing
            return View(sm);
        }

        // GET /student/createmodule/{id}
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateModule(int id)
        {
            var sm = svc.GetStudent(id);  
            if (sm == null)
            {
                Alert("StudentNot Found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }  
            var modules = svc.GetAvailableModulesForStudent(id);  
            var vm = new StudentModuleViewModel {
                Modules = new SelectList(modules,"Id","Title"),
                StudentId = id
            };  
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateModule([Bind("StudentId, ModuleId, Mark")] StudentModuleViewModel sm)
        {
            if (ModelState.IsValid)
            {                
                svc.AddStudentToModule(sm.StudentId, sm.ModuleId);
                svc.UpdateStudentModuleMark(sm.StudentId, sm.ModuleId, sm.Mark);
                return RedirectToAction(nameof(Details), new { Id = sm.StudentId });
            }
            // redisplay the form for editing  
            // note - we must re-create the selectlist and update view model Modules property
            //        this is because the form does not retain the select list values when posted to server
            var modules = svc.GetAvailableModulesForStudent(sm.StudentId);
            sm.Modules = new SelectList(modules,"Id","Title"); 
            return View(sm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteModule(int id)
        {
            var sm = svc.GetStudentModule(id);
            if (sm == null)
            {
                Alert("Student Modulet Found", AlertType.warning);
                return RedirectToAction(nameof(Index));   
            }   
            
            svc.RemoveStudentFromModule(sm.StudentId,sm.ModuleId);
            return RedirectToAction(nameof(Details), new { Id = sm.StudentId });
        }


    }
}
