using CoreWebApi.Entities;
using CoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DataAccess
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductModel> GetProductsWithDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                                on p.CategoryID equals c.CategoryId
                             select new ProductModel
                             {
                                 ProductId = p.ProductID,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();

            }

        }
    }
}
