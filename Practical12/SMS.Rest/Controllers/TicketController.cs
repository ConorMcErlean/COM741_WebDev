using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Data.Models;
using SMS.Data.Services;
using SMS.Rest.Dtos;

namespace SMS.Rest.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private StudentService _service;
        public TicketController() {
            this._service = new StudentService();
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            var tickets =  _service.GetAllTickets();
            // convert each ticket to a ticketdto via Select (projection)
            //return Ok(tickets.Select(t => TicketDto.FromTicket(t)).ToList());
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var ticket =  _service.GetTicket(id); 
            if (ticket == null)
            {
                return NotFound();
            }
           // convert ticket to dto 
           // return Ok(TicketDto.FromTicket(ticket));
           return Ok(ticket);           
        }

        [HttpPost] 
        //[Authorize(Roles="Admin,Manager")]   
        public IActionResult create(CreateTicketDto m)
        {
            if (ModelState.IsValid)
            {
                var result = _service.CreateTicket(m.StudentId,m.Issue);
                if (result != null)
                {
                    //return CreatedAtAction(nameof(Get), new { Id = result.Id }, TicketDto.FromTicket(result));
                    return CreatedAtAction(nameof(Get), new { Id = result.Id }, result);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]   
        public IActionResult delete(int id)
        {
            var ok = _service.DeleteTicket(id);
            if (ok)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
