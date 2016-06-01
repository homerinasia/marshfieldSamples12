using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldClientTcp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HelloWorldServiceRef.HelloWorldServiceClient();
            var msg = client.GetMessage("homer");
            var addr = client.Endpoint.Address;
            Console.WriteLine(msg + " from " + addr);
        }
    }
}
