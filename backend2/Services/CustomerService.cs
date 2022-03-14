using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Text.Json;

namespace backend.Services;

public static class CustomerService
{
    static List<Customer> Customers { get; }
    static int nextId = 3;
    static CustomerService()
    {
        Customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Asiakas 1", StreetAddress = "Kauppakatu 1", City = "Jyväskylä", State = "Keski-Suomi", Zip = "40100"},
            new Customer { Id = 1, Name = "Asiakas 2", StreetAddress = "Yliopistonkatu 2", City = "Jyväskylä", State = "Keski-Suomi", Zip = "40100"},
        };
    }
    public static List<Customer> GetAll() => Customers;
}