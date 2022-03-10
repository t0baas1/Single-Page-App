using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Test
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

        public static string haedata(String url){
            Console.WriteLine("Making API Call...");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                //client.BaseAddress = new Uri("http://www.filltext.com/");
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public static void parsija(string vastaus){
            dynamic dynJson = JsonConvert.DeserializeObject(vastaus);
            foreach(var item in dynJson){
                int id = item.id;
                string name = item.name;
                string streetAddress = item.address.streetAddress;
                string city = item.address.city;
                string state = item.address.state;
                string zip = item.address.zip;
            Console.WriteLine(name);
            }
        }
    }
}