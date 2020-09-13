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
    [Route("api/products")]
    public class ProductsController:Controller
    {
        ProductsService _productsService;
        public ProductsController (ProductsService productsService)
        {
            _productsService = productsService;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            var products = _productsService.GetProductsList();
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                var product = _productsService.GetProductList(Id);
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
                _productsService.AddProduct(product);
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
                _productsService.UpdateProduct(product);
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
                _productsService.DeleteProduct(Id);
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
              var result= _productsService.getDetails();
                return Ok(result);
            }
            catch
            {
            }
            return BadRequest();
        }
    }
}
