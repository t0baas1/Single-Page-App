using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CustomersEntities1();
            var customer = new Customer()
            {
                CustomerId = 998,
                Name = "Gugu gaga",
                StreetAddress = "Grove St.",
                City = "Constant Pain",
                State = "GG",
                Zip = "12345"
            };
            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}
