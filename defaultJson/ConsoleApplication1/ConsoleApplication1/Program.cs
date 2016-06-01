using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConsoleApplication1.ServiceReference1;
using System.Net.Http;
using System.Net;
using System.IO;

namespace ConsoleApplication1
{
    //http://dotnetmentors.com/wcf/wcf-rest-service-to-get-or-post-json-data-and-retrieve-json-data-with-datacontract.aspx
    //http://stackoverflow.com/questions/7585363/why-does-my-wcf-service-give-the-message-does-not-have-a-binding-with-the-none
    class Program
    {
        static void Main(string[] args)
        {
            // test pi real quick HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create("http://localhost:8733/Design_Time_Addresses/test0/Service1/getPersonById/2");
            HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create("http://piwebapi020160503084421.azurewebsites.net/api/housetemps");
            HttpWebResponse wresp = (HttpWebResponse)wreq.GetResponse();
            Stream content = wresp.GetResponseStream();
            StreamReader reader = new StreamReader(content, Encoding.UTF8);
            string data = reader.ReadToEnd();
            Person p = JsonConvert.DeserializeObject<Person>(data);

            string personAsJson = JsonConvert.SerializeObject(p);
            



            WebClient webClient = new WebClient();            
            webClient.Headers["Content-type"] = "application/json";            
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString("http://localhost:8733/Design_Time_Addresses/test0/Service1/makePerson", "POST", "33");

            WebRequest request = WebRequest.Create("http://localhost:8733/Design_Time_Addresses/test0/Service1/uploadPerson");
            request.Method = "POST";
            string postData = personAsJson;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();



        }
    }
}
