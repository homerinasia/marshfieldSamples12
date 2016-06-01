using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcTempDB0;

namespace mvcTempDB0.Controllers
{
    public class houseTempsController : Controller
    {
        private jmhtestANcq7BtzoEntities db = new jmhtestANcq7BtzoEntities();

        // GET: houseTemps
        public ActionResult Index()
        {
            return View(db.houseTemps.ToList());
        }

        // GET: houseTemps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            houseTemp houseTemp = db.houseTemps.Find(id);
            if (houseTemp == null)
            {
                return HttpNotFound();
            }
            return View(houseTemp);
        }

        // GET: houseTemps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: houseTemps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tds,tempF")] houseTemp houseTemp)
        {
            if (ModelState.IsValid)
            {
                db.houseTemps.Add(houseTemp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(houseTemp);
        }

        // GET: houseTemps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            houseTemp houseTemp = db.houseTemps.Find(id);
            if (houseTemp == null)
            {
                return HttpNotFound();
            }
            return View(houseTemp);
        }

        // POST: houseTemps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tds,tempF")] houseTemp houseTemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(houseTemp);
        }

        // GET: houseTemps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            houseTemp houseTemp = db.houseTemps.Find(id);
            if (houseTemp == null)
            {
                return HttpNotFound();
            }
            return View(houseTemp);
        }

        // POST: houseTemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            houseTemp houseTemp = db.houseTemps.Find(id);
            db.houseTemps.Remove(houseTemp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
