using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using CoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Services
{
    public class CustomerService
    {
        ICustomerDal _customerDal;
        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetCustomers()
        {   
            var customers =_customerDal.GetList();
            return customers;
        }

        public Customer GetCustomer(int Id)
        {
            return _customerDal.Get(x=>x.CustomerID==Id);
        }

        public Customer AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return customer;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);

            return customer;
        }
        public int DeleteCustomer (int Id)
        {
            _customerDal.Delete(new Customer { CustomerID=Id});

            return Id;
        }

        public List<CustomerModel> GetCustomerDetails()
        {
            var result = _customerDal.GetCustomerWithDetails();
            return result;
           
        }


    }
}
