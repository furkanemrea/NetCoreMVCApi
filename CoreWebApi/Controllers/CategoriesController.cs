using CoreWebApi.DataAccess;
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
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        
        private readonly CategoriesService _categoriesService;
        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            //var categoryList= categoriesService.GetCategories();
            //return Ok(categoryList);
            var categories = _categoriesService.GetCategories();
            return Ok(categories);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var category = _categoriesService.GetCategoryById(Id);
            return Ok(category);
        }
        public IActionResult Post(Category category)
        {
            try
            {
                _categoriesService.AddCategory(category);
                return new StatusCodeResult(201);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Put(Category category)
        {
            try
            {
                _categoriesService.UpdateCategory(category);
                return Ok(category);
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
                _categoriesService.DeleteCategory(Id);
                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }

    }
}
