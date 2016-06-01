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

namespace piWebAPI0.Controllers
{
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
    }
}