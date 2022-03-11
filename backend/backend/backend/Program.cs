using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CustomersEntities();
            var customer = new Customer()
            {
                CustomerId = 999,
                Name = "Gugu",
                StreetAddress = "Grove St.",
                City = "Shit-city",
                State = "Constant Pain",
                Zip = "696969"
            };
            context.Customer.Add(customer);
            context.SaveChanges();
        }
    }
}
