using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string photo { get; set; }

        public int CountryId { get; set; }

        public int DepartmentId { get; set; }



    }
}
