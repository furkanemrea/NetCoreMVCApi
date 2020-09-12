using CoreWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DataAccess
{
    public class EfCountryDal : EfEntityRepositoryBase<Country, NorthwindContext>, ICountryDal
    {

    }
}
