using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace HostCmdLineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(HelloWorldService.HelloWorldService),
                new Uri("http://localhost:55859/HostCmdLineApp/HelloWorldService.svc"));
            host.Open();
            Console.WriteLine("HelloWorldService is now running");
            Console.WriteLine("press any key to stop");
            Console.ReadKey();
            host.Close();
        }
    }
}
