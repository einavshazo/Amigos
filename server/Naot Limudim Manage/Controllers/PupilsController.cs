using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Naot_Limudim_Manage.Models;

namespace Naot_Limudim_Manage.Controllers
{
    public class PupilsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pupils
        public ActionResult Index()
        {
            var pupils = db.Pupils.Include(p => p.School).Include(p => p.YearOfStudy);
            return View(pupils.ToList());
        }

        // GET: Pupils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupil pupil = db.Pupils.Find(id);
            if (pupil == null)
            {
                return HttpNotFound();
            }
            return View(pupil);
        }

        // GET: Pupils/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(db.Schools, "ID", "Name");
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "ID", "Year");
            return View();
        }

        // POST: Pupils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LastName,Phone,YearOfStudyID,SchoolID")] Pupil pupil)
        {
            if (ModelState.IsValid)
            {
                db.Pupils.Add(pupil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolID = new SelectList(db.Schools, "ID", "Name", pupil.SchoolID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "ID", "Year", pupil.YearOfStudyID);
            return View(pupil);
        }

        // GET: Pupils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupil pupil = db.Pupils.Find(id);
            if (pupil == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolID = new SelectList(db.Schools, "ID", "Name", pupil.SchoolID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "ID", "Year", pupil.YearOfStudyID);
            return View(pupil);
        }

        // POST: Pupils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LastName,Phone,YearOfStudyID,SchoolID")] Pupil pupil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pupil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolID = new SelectList(db.Schools, "ID", "Name", pupil.SchoolID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "ID", "Year", pupil.YearOfStudyID);
            return View(pupil);
        }

        // GET: Pupils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupil pupil = db.Pupils.Find(id);
            if (pupil == null)
            {
                return HttpNotFound();
            }
            return View(pupil);
        }

        // POST: Pupils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pupil pupil = db.Pupils.Find(id);
            db.Pupils.Remove(pupil);
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
