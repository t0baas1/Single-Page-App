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
        string url = "http://www.filltext.com/?rows=100&pretty=true&id={index}&name={business}&address={addressObject}";
        string vastaus = haedata(url);
        parsija(vastaus);

        Customers = new List<Customer>{};

        static string haedata(String url)
        {
            Console.WriteLine("Making API Call...");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        static void parsija(string vastaus)
        {
            Console.WriteLine(vastaus);
            Customer customerdata = JsonSerializer.Deserialize<Customer>(vastaus);
 
            Customers.Add(customerdata);
;

        }
 
    }


    

    public static List<Customer> GetAll() => Customers;

}