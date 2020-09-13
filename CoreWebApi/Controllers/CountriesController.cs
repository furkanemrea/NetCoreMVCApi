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
    [Route("api/countries")]
    public class CountriesController : Controller
    {
        ICountryDal _countryDal;
        CountriesService _countriesService;
        public CountriesController(CountriesService countriesService)
        {
            _countriesService = countriesService;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _countriesService.GetCountries();
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
                var result = _countriesService.GetCountry(Id);
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
                _countriesService.UpdateCountry(country);
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
                _countriesService.AddCountry(country);
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
                _countriesService.DeleteCountry(Id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
