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
using Microsoft.AspNetCore.Authorization;

namespace SMS.Web.Controllers
{

    [Authorize]
    public class TicketController : BaseController
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

        [Authorize(Roles="Admin,Manager")]
        //  POST /ticket/close/{id}
        [HttpPost]
        public IActionResult Close(int id)
        {
            // close ticket via service
            var t = svc.CloseTicket(id);
            if (t == null)
            {
                Alert("Ticket Not Found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            Alert("Ticket Closed", AlertType.info);
            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET /ticket/create
        public IActionResult Create()
        {
            // create the view model and initialise the selectlist
            var students = svc.GetAllStudents();
            var tvm = new TicketViewModel {
                Students = new SelectList(students,"Id","Name") 
            };
            
            // render blank form
            return View( tvm );
        }

        [Authorize(Roles = "Admin,Manager")]
        // POST /ticket/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StudentId,Issue")]TicketViewModel tvm)
        {
            if (ModelState.IsValid)
            {
                svc.CreateTicket(tvm.StudentId, tvm.Issue);
                Alert("Ticket Created Successfully", AlertType.info);
                return RedirectToAction(nameof(Index));
            }
            // initialise the selectlist as it is not retained on submission of form
            var students = svc.GetAllStudents();
            tvm.Students = new SelectList(students,"Id","Name");  
            // redisplay the form for editing
            return View(tvm);
        }
    }
}
