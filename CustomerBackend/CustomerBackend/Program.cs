using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace CustomerBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.filltext.com/?rows=100&pretty=true&id={index}&name={business}&address={addressObject}";
            string vastaus = haedata(url);
            //Console.WriteLine(vastaus);

            parsija(vastaus);
        }

        public static string haedata(String url)
        {
            Console.WriteLine("Making API Call...");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                //client.BaseAddress = new Uri("http://www.filltext.com/");
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }
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
    }
}
