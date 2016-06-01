using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class FamilyController : Controller
    {
        private jmhtestANcq7BtzoEntities1 db = new jmhtestANcq7BtzoEntities1();

        //
        // GET: /Family/

        public ActionResult Index()
        {
            return View(db.families.ToList());
        }

        //
        // GET: /Family/Details/5

        public ActionResult Details(int id = 0)
        {
            family family = db.families.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        //
        // GET: /Family/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Family/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(family family)
        {
            if (ModelState.IsValid)
            {
                db.families.Add(family);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(family);
        }

        //
        // GET: /Family/Edit/5

        public ActionResult Edit(int id = 0)
        {
            family family = db.families.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        //
        // POST: /Family/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(family family)
        {
            if (ModelState.IsValid)
            {
                db.Entry(family).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(family);
        }

        //
        // GET: /Family/Delete/5

        public ActionResult Delete(int id = 0)
        {
            family family = db.families.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        //
        // POST: /Family/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            family family = db.families.Find(id);
            db.families.Remove(family);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}