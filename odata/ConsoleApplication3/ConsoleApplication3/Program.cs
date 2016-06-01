using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:15072/odata/");
            ServiceReference1.Container container = new ServiceReference1.Container(uri);
            container.SendingRequest2 += (s, e) =>
                {
                    Console.WriteLine("", e.RequestMessage.Method, e.RequestMessage.Url);
                };
            foreach (var item in container.titles)
            {
                Console.WriteLine(item.title1);
            }
            
        }
    }
}
