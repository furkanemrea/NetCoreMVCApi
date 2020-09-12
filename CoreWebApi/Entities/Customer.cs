using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Entities
{
    public class Customer:IEntity
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Gender { get; set; }
        public int Country { get; set; }


    }
}
