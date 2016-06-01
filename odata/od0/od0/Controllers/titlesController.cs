using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using od0;

namespace od0.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using od0;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<title>("titles");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class titlesController : ODataController
    {
        private pubsEntities db = new pubsEntities();

        // GET: odata/titles
        [Queryable]
        public IQueryable<title> Gettitles()
        {
            return db.titles;
        }

        // GET: odata/titles(5)
        [Queryable]
        public SingleResult<title> Gettitle([FromODataUri] string key)
        {
            return SingleResult.Create(db.titles.Where(title => title.title_id == key));
        }

        // PUT: odata/titles(5)
        public IHttpActionResult Put([FromODataUri] string key, title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != title.title_id)
            {
                return BadRequest();
            }

            db.Entry(title).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!titleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(title);
        }

        // POST: odata/titles
        public IHttpActionResult Post(title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.titles.Add(title);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (titleExists(title.title_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(title);
        }

        // PATCH: odata/titles(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<title> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            title title = db.titles.Find(key);
            if (title == null)
            {
                return NotFound();
            }

            patch.Patch(title);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!titleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(title);
        }

        // DELETE: odata/titles(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            title title = db.titles.Find(key);
            if (title == null)
            {
                return NotFound();
            }

            db.titles.Remove(title);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool titleExists(string key)
        {
            return db.titles.Count(e => e.title_id == key) > 0;
        }
    }
}
