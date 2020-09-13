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
    [Route("api/customers")]
    public class CustomerController : Controller
    {


        CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _customerService.GetCustomers();
                return Ok(results);
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
                var result = _customerService.GetCustomer(Id);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        public IActionResult Post(Customer customer)
        {
            try
            {
                _customerService.AddCustomer(customer);
                return new StatusCodeResult(201);
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            try
            {
                _customerService.UpdateCustomer(customer);
                return Ok(customer);
            }
            catch
            {
                return BadRequest();

            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _customerService.DeleteCustomer(Id);
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }



        [HttpGet("GetCustomerDetails")]
        public IActionResult GetCustomerDetails()
        {
            try
            {
                var result = _customerService.GetCustomerDetails();
                return Ok(result);
            }
            catch
            {
            }
            return BadRequest();
        }
    }
}
