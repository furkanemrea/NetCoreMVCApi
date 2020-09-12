﻿using CoreWebApi.Entities;
using CoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DataAccess
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        List<CustomerModel> GetCustomerWithDetails();
    }
}
