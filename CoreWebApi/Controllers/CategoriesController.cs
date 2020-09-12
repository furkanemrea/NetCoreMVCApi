using CoreWebApi.DataAccess;
using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/categories")]
    public class CategoriesController: Controller
    {
        ICategoryDal _categoryDal;

        public CategoriesController(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            var categories = _categoryDal.GetList();
            return Ok(categories);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var category = _categoryDal.Get(x => x.CategoryId == Id);
            return Ok(category);
        }

       
        public IActionResult Post(Category category)
        {
            try
            {
                _categoryDal.Add(category);
                return new StatusCodeResult(201);
            }
            catch
            {

                return BadRequest();
            }
            
        }

    }
}
