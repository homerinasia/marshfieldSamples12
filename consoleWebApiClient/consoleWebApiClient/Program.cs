using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace consoleWebApiClient
{
    class Program
    {
        class Person
        {
            public int  Id { get; set; }
            public string Fname { get; set; }
        }

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49922");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/People/1");
                if (response.IsSuccessStatusCode)
                {
                    Person person = await response.Content.ReadAsAsync<Person>();
                    Console.WriteLine("{0}\t{1}", person.Id, person.Fname);
                }

                // HTTP GET
                response = await client.GetAsync("api/FindByLetter/e");
                if (response.IsSuccessStatusCode)
                {
                    List<Person> persons = await response.Content.ReadAsAsync<List<Person>>();                    
                }
            }
        }
    }
}
