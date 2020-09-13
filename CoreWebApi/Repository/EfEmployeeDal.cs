using CoreWebApi.Entities;
using CoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DataAccess
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, NorthwindContext>, IEmployeeDal
    {
        public List<EmployeeModel> GetEmployeesWithDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from e in context.Employees
                             join c in context.Countries
                             on e.CountryId equals c.Id
                             join d in context.Departments
                             on e.DepartmentId equals d.Id
                             select new EmployeeModel
                             {
                                 DepartmentName = d.DepartmentName,
                                 CountryName = c.CountryName,
                                 FirstName = e.FirstName,
                                 LastName = e.LastName,
                                 Id = e.Id,
                                 photo = e.photo
                             };
                return result.ToList();

            }

        }
    }
}
