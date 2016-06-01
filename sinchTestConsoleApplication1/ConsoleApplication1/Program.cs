using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinch.ServerSdk;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            //var smsApi = SinchFactory.CreateApiFactory("d9dec293-0872-4357-91e9-fae9e8868ffe", "YTNXHvXQLUiwjpe68vPEqQ==").CreateSmsApi();
            //var sendSmsResponse = smsApi.Sms("+19186250515", "Hello world.  Sinch SMS here.").Send();

        }

        private static async Task MainAsync()
        {
            var smsApi = SinchFactory.CreateApiFactory("d9dec293-0872-4357-91e9-fae9e8868ffe", "YTNXHvXQLUiwjpe68vPEqQ==").CreateSmsApi();
            var sendSmsResponse = await smsApi.Sms("+19186250515", "Hello world.  Sinch SMS here.").Send();
            //await Task.Delay(TimeSpan.FromSeconds(10));
        }
    }

    
    
}
