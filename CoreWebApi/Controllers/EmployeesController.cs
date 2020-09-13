using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using CoreWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/employees")]
    public class EmployeesController:Controller
    {
        EmployeesService _employeeService;
        public EmployeesController(EmployeesService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var employeList = _employeeService.GetEmployees();
                return Ok(employeList);
            }
            catch 
            {
                return BadRequest();
            }
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                var emp = _employeeService.GetEmployeeById(Id);
                return Ok(emp);
            }
            catch 
            {
                return BadRequest();
            }
        }
        public IActionResult Post(Employee employee)
        {
            try
            {
                _employeeService.AddEmployee(employee);
                return new StatusCodeResult(201);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            try
            {
                _employeeService.UpdateEmployee(employee);
                return Ok(employee);
            }
            catch 
            {
                return BadRequest();
            }
            
        }

        [HttpGet("GetEmployeeDetails")]
        public IActionResult GetEmployeesWithDetails()
        {
            try
            {
                var result = _employeeService.GetEmployeeDetails();
                return Ok(result);
            }
            catch 
            {

                return BadRequest();
            }
        }
    }
}
