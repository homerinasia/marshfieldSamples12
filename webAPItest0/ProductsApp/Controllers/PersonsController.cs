using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class PersonsController : ApiController
    {
        Person[] persons = new Person[] 
        { 
            new Person { Id = 1, Name = "joe"}, 
            new Person { Id = 2, Name = "fred"}, 
            new Person { Id = 3, Name = "suzy"} 
        };

        //public IEnumerable<Person> GetAllPersons()
        //{
        //    return persons;
        //}

        //public IHttpActionResult GetPerson(int id)
        //{
        //    var person = persons.FirstOrDefault((p) => p.Id == id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(person);
        //}

        //public IHttpActionResult PostPerson(int id)
        //{
        //    Person person = new Person { Id = id, Name = "blah" };
        //    return Ok(person);
        //}

        [Route("api/GetPerson")]
        public IHttpActionResult GetPerson()
        {

            Person person = new Person { Id = 5, Name = "blah" };
            return Ok(person);
        }

        [Route("api/PostPerson")]
        public IHttpActionResult PostPerson(Person p)
        {

            Person person = new Person { Id = 5, Name = "blah" };
            return Ok(person);
        }

        
        //[Route("api/Post1Person/{id?}")]
        //public HttpResponseMessage Post(HttpRequestMessage request)
        //{
        //    Person p = request.Content.ReadAsAsync<Person>().Result;
        //    return Request.CreateResponse(HttpStatusCode.OK, persons);
        //}

        [Route("api/Post1Person/{id?}")]
        public HttpResponseMessage Post(Person p)
        {            
            return Request.CreateResponse(HttpStatusCode.OK, persons);
        }
    }
}
