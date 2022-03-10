using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace database.DbModels
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string  StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set;  }
    }
}
