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

            // verify ticket found and if not return NotFound()

            // call service method to close the ticket

            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }

        // GET /ticket/create
        public IActionResult Create()
        {
            // call service methods to return all students
            

            // create a TicketViewModel and set Students property 
            // as selectlist containing student Id and Name
           
            
            // render form - passing view model created
            return View( );
        }

        // POST /ticket/create
        [HttpPost]
        public IActionResult Create(TicketViewModel tvm)
        {
            // if valid model
            //   call service to create ticket
            //   redirect to index action      
            // end

            // redisplay the form passing viewmodel for editing
            return View(  );
        }
    }
}
