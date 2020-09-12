using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/employee")]
    public class EmployeesController:Controller
    {
        IEmployeeDal _employeeDal;
        public EmployeesController(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var empList = _employeeDal.GetList();
                return Ok(empList);
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
                var emp = _employeeDal.Get(x => x.Id == Id);
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
                _employeeDal.Add(employee);
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
                _employeeDal.Update(employee);
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
                var result = _employeeDal.GetEmployeesWithDetails();
                return Ok(result);
            }
            catch 
            {

                return BadRequest();
            }
        }
    }
}
