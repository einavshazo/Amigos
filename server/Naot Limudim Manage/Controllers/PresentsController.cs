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
    public class PresentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Presents
        public ActionResult Index()
        {
            var presents = db.Presents.Include(p => p.CLass).Include(p => p.Pupil);
            return View(presents.ToList());
        }

        // GET: Presents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Present present = db.Presents.Find(id);
            if (present == null)
            {
                return HttpNotFound();
            }
            return View(present);
        }

        // GET: Presents/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Topic");
            ViewBag.PupilID = new SelectList(db.Pupils, "ID", "Name");
            return View();
        }

        // POST: Presents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IsPresent,ClassID,PupilID")] Present present)
        {
            if (ModelState.IsValid)
            {
                db.Presents.Add(present);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Topic", present.ClassID);
            ViewBag.PupilID = new SelectList(db.Pupils, "ID", "Name", present.PupilID);
            return View(present);
        }

        // GET: Presents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Present present = db.Presents.Find(id);
            if (present == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Topic", present.ClassID);
            ViewBag.PupilID = new SelectList(db.Pupils, "ID", "Name", present.PupilID);
            return View(present);
        }

        // POST: Presents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IsPresent,ClassID,PupilID")] Present present)
        {
            if (ModelState.IsValid)
            {
                db.Entry(present).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Topic", present.ClassID);
            ViewBag.PupilID = new SelectList(db.Pupils, "ID", "Name", present.PupilID);
            return View(present);
        }

        // GET: Presents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Present present = db.Presents.Find(id);
            if (present == null)
            {
                return HttpNotFound();
            }
            return View(present);
        }

        // POST: Presents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Present present = db.Presents.Find(id);
            db.Presents.Remove(present);
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
