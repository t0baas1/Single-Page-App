using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace CustomerBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.filltext.com/?rows=100&pretty=true&id={index}&name={business}&address={addressObject}";
            string vastaus = haedata(url);

            parsija(vastaus);

            tulostus();
        }

        // Haetaan annetusta urlista data. 
        public static string haedata(String url)
        {
            Console.WriteLine("Making API Call...");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        
        
        // Parsitaan saatu data, ja tallennetaan yhdistettyyn tietokantaan.
        public static void parsija(string vastaus)
        {
            var context = new CustomersEntities1();
            dynamic dynJson = JsonConvert.DeserializeObject(vastaus);
            foreach (var item in dynJson)
            {
                var customer = new Customer()
                {
                    CustomerId = item.id,
                    Name = item.name,
                    StreetAddress = item.address.streetAddress,
                    City = item.address.city,
                    State = item.address.state,
                    Zip = item.address.zip,
                };
                context.Customers.Add(customer);
            }
            context.SaveChanges();
        }

        // Tulostetaan halutut tiedot kannasta
        public static void tulostus()
        {
            using (var context = new CustomersEntities1())
            {
                // Querytetään halutut tiedot
                var blogs = from b in context.Customers
                            select b;
                foreach(var item in blogs)
                {
                    Console.WriteLine(item.Name);
                }



            }
        }


    }
}
