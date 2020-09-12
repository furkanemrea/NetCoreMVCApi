using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {

        ICustomerDal _customerDal;
        public CustomerController(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _customerDal.GetList();
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
                var result = _customerDal.Get(x => x.CustomerID == Id);
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
                _customerDal.Add(customer);
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
                _customerDal.Update(customer);
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
                _customerDal.Delete(new Customer { CustomerID = Id });
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
                var result = _customerDal.GetCustomerWithDetails();
                return Ok(result);
            }
            catch
            {
            }
            return BadRequest();
        }
    }
}
