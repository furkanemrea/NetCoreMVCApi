using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using CoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Services
{
    public class ProductsService
    {
        IProductDal _productDal;

        public ProductsService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetProductsList()
        {
            var result = _productDal.GetList();
            return result;
        }
        public Product GetProductList(int Id)
        {
            var result = _productDal.Get(x=>x.ProductID==Id);

            return result;
        }

        public Product AddProduct(Product product)
        {
            _productDal.Add(product);
            return product;
        }
        public Product UpdateProduct(Product product)
        {
            _productDal.Update(product);
            return product;
        }
        public int DeleteProduct(int Id)
        {

            _productDal.Delete(new Product {ProductID=Id });
            return Id;
        }

        public List<ProductModel> getDetails()
        {
           var result= _productDal.GetProductsWithDetails();
            return result;
        }



    }
}
