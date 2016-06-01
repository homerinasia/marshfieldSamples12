using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using simpleWApi0.Models;

namespace simpleWApi0.Controllers
{
    // for the auth attributes to work this must be deployed to iis and both anon and win auth enabled. 
    public class PersonsController : ApiController
    {
        // GET: api/Persons
        [AllowAnonymous]
        public string Get()
        {
            return User.Identity.IsAuthenticated.ToString();
        }

        // GET: api/Persons/5
        public int Get(int id)
        {
            return id;
        }

        // POST: api/Persons
        [Authorize]
        public string Post(Person p)
        {
            return User.Identity.IsAuthenticated + " " + User.Identity.AuthenticationType + " " + User.Identity.Name;
        }

        // PUT: api/Persons/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Persons/5
        public void Delete(int id)
        {
        }
    }
}
