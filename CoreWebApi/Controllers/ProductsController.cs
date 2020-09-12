using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/products")]
    public class ProductsController:Controller
    {
        IProductDal _productDal;
        public ProductsController (IProductDal productDal)
        {
            _productDal = productDal;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            var products = _productDal.GetList();
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                var product = _productDal.Get(p => p.ProductID == Id);
                if (product ==null)
                {
                    return NotFound($"There is no product with Id ={Id}");
                }
                    return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //Gelen Data Json a çevireceğin zaman [FromBody] Kullan
        public IActionResult Post(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);
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
                _productDal.Delete(new Product{ ProductID=Id});
                return Ok();
                    
            }
            catch 
            {

                return BadRequest();
            }
        }

        [HttpGet("GetProductDetails")]
        public IActionResult GetProductWithDetails()
        {
            try
            {
              var result=  _productDal.GetProductsWithDetails();
                return Ok(result);
            }
            catch
            {
            }
            return BadRequest();
        }
    }
}
