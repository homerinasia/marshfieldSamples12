using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using piWebAPI0;
using System.Threading.Tasks;
using Sinch.ServerSdk;
using System.Web.Http.Cors;


namespace piWebAPI0.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class houseTempsController : ApiController
    {
        private tempEntities db = new tempEntities();

        // GET: api/houseTemps
        public IQueryable<houseTemp> GethouseTemps()
        {
            return db.houseTemps;
        }

        // GET: api/houseTemps/5
        [ResponseType(typeof(houseTemp))]
        public IHttpActionResult GethouseTemp(int id)
        {
            houseTemp houseTemp = db.houseTemps.Find(id);
            if (houseTemp == null)
            {
                return NotFound();
            }

            return Ok(houseTemp);
        }

        // PUT: api/houseTemps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuthouseTemp(int id, houseTemp houseTemp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != houseTemp.Id)
            {
                return BadRequest();
            }

            db.Entry(houseTemp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!houseTempExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/houseTemps
        [ResponseType(typeof(houseTemp))]
        public IHttpActionResult PosthouseTemp(houseTemp houseTemp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.houseTemps.Add(houseTemp);
            db.SaveChanges();

            if((houseTemp.tempF < 65) || (houseTemp.tempF > 80)) MainAsync((decimal)houseTemp.tempF);

            return CreatedAtRoute("DefaultApi", new { id = houseTemp.Id }, houseTemp);
        }

        // DELETE: api/houseTemps/5
        [ResponseType(typeof(houseTemp))]
        public IHttpActionResult DeletehouseTemp(int id)
        {
            houseTemp houseTemp = db.houseTemps.Find(id);
            if (houseTemp == null)
            {
                return NotFound();
            }

            db.houseTemps.Remove(houseTemp);
            db.SaveChanges();

            return Ok(houseTemp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool houseTempExists(int id)
        {
            return db.houseTemps.Count(e => e.Id == id) > 0;
        }

        public void MainAsync(decimal fTemp)
        {
            var smsApi = SinchFactory.CreateApiFactory("d9dec293-0872-4357-91e9-fae9e8868ffe", "YTNXHvXQLUiwjpe68vPEqQ==").CreateSmsApi();
            var sendSmsResponse = smsApi.Sms("+19186250515", string.Format("Temp is {0}", fTemp)).Send();
        }
    }
}