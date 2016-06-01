using System;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

//http://www.codeproject.com/Articles/167159/How-to-create-a-JSON-WCF-RESTful-Service-in-sec
namespace WcfJsonRestService
{
    public class Service1 : IService1
    {
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "getAllPersons")]
        public List<Person> getAllPersons()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("joe", 1));
            persons.Add(new Person("fred", 2));
            persons.Add(new Person("suzy", 3));
            return persons;
            
        }

        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "getPersonById/{Id}")]
        public IEnumerable<Person> getPersonById(string Id)
        {
            int id = int.Parse(Id);
            List<Person> persons = new List<Person>();
            persons.Add(new Person("joe", 1));
            persons.Add(new Person("fred", 2));
            persons.Add(new Person("suzy", 3));
            IEnumerable<Person> p = from person in persons
                       where person.Id == id
                       select person;
            return p;
        }
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}


















/*
public List<Person> GetData(string id)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("joe", 1));
            persons.Add(new Person("fred", 2));
            persons.Add(new Person("suzy", 3));
            return persons;
            //return new Person("bob", 4);
            //return new Person()
            //{
            //    Id = Convert.ToInt32(id),
            //    Name = "Leo Messi"
            //};
        }

*/