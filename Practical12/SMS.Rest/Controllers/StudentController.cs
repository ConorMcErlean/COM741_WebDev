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
    public class StudentController : ControllerBase
    {
        private StudentService _service;

        public StudentController() {
            this._service = new StudentService();
        }

        // add actions to support CRUD methods listed in practical questions
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllStudents());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetStudent(id));
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public IActionResult Create(StudentDto s)
        {
            if (ModelState.IsValid)
            {
                var Student = _service.AddStudent(s.Name, s.Email, s.Course, s.Age, s.Grade);
                if (Student != null)
                {
                    return CreatedAtAction(nameof(Get), new {Id = Student.Id}, Student);
                }
            }
            return BadRequest(ModelState);
        }//Create
        [Authorize(Roles="Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ok = _service.DeleteStudent(id);
            if (ok)
            {
                return Ok();
            }
            return NotFound();
        }//Delete
        [Authorize(Roles="Admin, Manager")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentDto s)
        {
            var updated = new Student
            {
            Name = s.Name, 
            Email = s.Email, 
            Course = s.Course,
            Age = s.Age,
            Id = s.Id,
            Profile = new Profile{ Grade = s.Grade}
            };
            var result = _service.UpdateStudent(id, updated);
            if (result != null)
            {
                return Ok(_service.GetStudent(id));
            }
            return NotFound();
        }//Update
    }// Class
}// Namespace
