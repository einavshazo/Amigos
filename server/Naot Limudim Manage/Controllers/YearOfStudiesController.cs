<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Naot_Lemida_Manage_V2.Models;

namespace Naot_Lemida_Manage_V2.Controllers
{
    public class YearOfStudiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: YearOfStudies
        public ActionResult Index()
        {
            return View(db.YearOfStudies.ToList());
        }


        // GET: YearOfStudies/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: YearOfStudies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Year")] YearOfStudy yearOfStudy)
        {
            if (ModelState.IsValid)
            {
                db.YearOfStudies.Add(yearOfStudy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearOfStudy);
        }

        // GET: YearOfStudies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            if (yearOfStudy == null)
            {
                return HttpNotFound();
            }
            return PartialView(yearOfStudy);
        }

        // POST: YearOfStudies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Year")] YearOfStudy yearOfStudy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearOfStudy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearOfStudy);
        }

        // GET: YearOfStudies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            if (yearOfStudy == null)
            {
                return HttpNotFound();
            }
            return PartialView(yearOfStudy);
        }

        // POST: YearOfStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            db.YearOfStudies.Remove(yearOfStudy);
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
=======
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Naot_Lemida_Manage_V2.Models;

namespace Naot_Lemida_Manage_V2.Controllers
{
    public class YearOfStudiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: YearOfStudies
        public ActionResult Index()
        {
            return View(db.YearOfStudies.ToList());
        }


        // GET: YearOfStudies/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: YearOfStudies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Year")] YearOfStudy yearOfStudy)
        {
            if (ModelState.IsValid)
            {
                db.YearOfStudies.Add(yearOfStudy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearOfStudy);
        }

        // GET: YearOfStudies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            if (yearOfStudy == null)
            {
                return HttpNotFound();
            }
            return PartialView(yearOfStudy);
        }

        // POST: YearOfStudies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Year")] YearOfStudy yearOfStudy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearOfStudy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearOfStudy);
        }

        // GET: YearOfStudies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            if (yearOfStudy == null)
            {
                return HttpNotFound();
            }
            return PartialView(yearOfStudy);
        }

        // POST: YearOfStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            db.YearOfStudies.Remove(yearOfStudy);
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
>>>>>>> 8cbf1b4a2470f83c1ccc3768d1841cd020cfc01a
