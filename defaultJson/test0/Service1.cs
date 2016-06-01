using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;


namespace test0
{
    // http://localhost:8733/Design_Time_Addresses/test0/Service1/getPersonById/2
    // http://localhost:8733/Design_Time_Addresses/test0/Service1/makePerson/44
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        
        public Person getPersonById(string Id)
        {
            int id = int.Parse(Id);
            List<Person> persons = new List<Person>();
            persons.Add(new Person("joe", 1));
            persons.Add(new Person("fred", 2));
            persons.Add(new Person("suzy", 3));
            IEnumerable<Person> p = from person in persons
                                    where person.Id == id
                                    select person;
            return p.FirstOrDefault();
        }

       
        public Person makePerson(string Id)
        {
            Person person = new Person("blah", int.Parse(Id));
            //Person person = new Person("blah", 55);
            return person;         
        }



        public int uploadPerson(Person p)
        {
            return p.Id;
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
