using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/country")]
    public class CountriesController : Controller
    {
        ICountryDal _countryDal;
        public CountriesController(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _countryDal.GetList();
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
                var result = _countryDal.Get(x => x.Id == Id);
                return Ok(result);
            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult Put(Country country)
        {
            try
            {
                _countryDal.Update(country);
                return Ok(country);
            }
            catch
            {

                return BadRequest();
            }


        }

        public IActionResult Post(Country country)
        {
            try
            {
                _countryDal.Add(country);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _countryDal.Delete(new Country { Id = Id });
                return Ok();
            }
            catch
            {

                return BadRequest();
            }

        }

    }
}
