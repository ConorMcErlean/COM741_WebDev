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
        
    }
}
