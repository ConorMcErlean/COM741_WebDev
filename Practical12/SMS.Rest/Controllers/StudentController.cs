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

    [ApiController]ic
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
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetStudent(id));
        }

        [HttpPost]
        public IActionResult Create(StudentDto s)
        {

            if (ModelState.IsValid)
            {
                var Student = _service.AddStudent(s.Name, s.Email, s.Course, s.Age, s.Grade);
                if (Student != null)
                {
                    CreatedAtAction(nameof(Get), new {Id = Student.Id}, Student);
                }
            }
            return BadRequest(ModelState);
        }//Create
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
        [HttpPut]
        public IActionResult Update(int id, StudentDto s)
        {
            var result = _service.UpdateStudent(id, s);
            if (result != null)
            {
                return Ok(_service.GetStudent(id));
            }
            return NotFound();
        }//Update
    }
}