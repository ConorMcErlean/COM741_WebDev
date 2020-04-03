using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMS.Web.Models;
using SMS.Data.Models;
using SMS.Data.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SMS.Web.Controllers
{
    public class TicketController : Controller
    {

        private readonly StudentService svc;
        public TicketController()
        {
            svc = new StudentService();
        }

        // GET /ticket/index
        public IActionResult Index()
        {
            var tickets = svc.GetOpenTickets();
            return View(tickets);
        }

        //  POST /ticket/close/{id}
        [HttpPost]
        public IActionResult Close(int id)
        {
            // load ticket via service
            // call service method to close the ticket
            var s = svc.CloseTicket(id);

            // verify ticket found and if not return NotFound()
            if (s == null){
                return NotFound();
            }
            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }

        // GET /ticket/create
        public IActionResult Create()
        {
            // call service methods to return all students
            var students = svc.GetAllStudents();

            // create a TicketViewModel and set Students property 
            // as selectlist containing student Id and Name
            var tvm = new TicketViewModel{
                Students = new SelectList(students, "Id", "Name")
            };
            
            // render form - passing view model created
            return View(tvm);
        }

        // POST /ticket/create
        [HttpPost]
        public IActionResult Create(TicketViewModel tvm)
        {
            // if valid model
            if (ModelState.IsValid){
                //   call service to create ticket
                svc.CreateTicket(tvm.StudentId, tvm.Issue); 
                //   redirect to index action
                return RedirectToAction(nameof(Index));      
                // end
            }
            // redisplay the form passing viewmodel for editing
            return View(tvm);
        }
    }
}
