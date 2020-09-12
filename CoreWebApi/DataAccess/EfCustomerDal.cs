
using CoreWebApi.Entities;
using CoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DataAccess
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
        public List<CustomerModel> GetCustomerWithDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from x in context.Customers
                             join y in context.Countries
                             on x.Country equals y.Id
                             select new CustomerModel
                             {
                                 CustomerID = x.CustomerID,
                                 Name = x.Name,
                                 Surname = x.Surname,
                                 Mail = x.Mail,
                                 Gender = x.Gender,
                                 Country = y.CountryName

                             };
                return result.ToList();
            }
        }
    }
}
