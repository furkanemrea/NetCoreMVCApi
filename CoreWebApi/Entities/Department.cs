using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Entities
{
    public class Department:IEntity
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }
    }
}
