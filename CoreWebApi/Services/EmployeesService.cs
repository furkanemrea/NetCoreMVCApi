using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using CoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Services
{
    public class EmployeesService
    {
        IEmployeeDal _employeeDal;
        public EmployeesService(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public List<Employee> GetEmployees()
        {
            var result = _employeeDal.GetList();
            return result;
        }
        public Employee GetEmployeeById(int Id)
        {
            var result = _employeeDal.Get(x=>x.Id==Id);
            return result;
        }

        public Employee AddEmployee(Employee employee)
        {
            _employeeDal.Add(employee);
            return employee;
        }
        public Employee UpdateEmployee(Employee employee)
        {

            _employeeDal.Update(employee);
            return employee;
        }
        public int DeleteEmployee(int Id)
        {
            _employeeDal.Delete(new Employee {Id=Id });
            return Id;
        }

        public List<EmployeeModel> GetEmployeeDetails()
        {
            var result= _employeeDal.GetEmployeesWithDetails();
            return result;
        }

    }
}
