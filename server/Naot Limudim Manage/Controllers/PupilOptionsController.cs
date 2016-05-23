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
    public class PupilOptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PupilOptions
        public ActionResult Index()
        {
            var pupilOptions = db.PupilOptions.Include(p => p.Pupil);
            return View(pupilOptions.ToList());
        }

        // GET: PupilOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PupilOption pupilOption = db.PupilOptions.Find(id);
            if (pupilOption == null)
            {
                return HttpNotFound();
            }
            return View(pupilOption);
        }

        // GET: PupilOptions/Create
        public ActionResult Create()
        {
            ViewBag.PupilID = new SelectList(db.Pupils, "ID", "Name");
            return View();
        }

        // POST: PupilOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Start,End,PupilID")] PupilOption pupilOption)
        {
            if (ModelState.IsValid)
            {
                db.PupilOptions.Add(pupilOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PupilID = new SelectList(db.Pupils, "ID", "Name", pupilOption.PupilID);
            return View(pupilOption);
        }

        // GET: PupilOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PupilOption pupilOption = db.PupilOptions.Find(id);
            if (pupilOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.PupilID = new SelectList(db.Pupils, "ID", "Name", pupilOption.PupilID);
            return View(pupilOption);
        }

        // POST: PupilOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Start,End,PupilID")] PupilOption pupilOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pupilOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PupilID = new SelectList(db.Pupils, "ID", "Name", pupilOption.PupilID);
            return View(pupilOption);
        }

        // GET: PupilOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PupilOption pupilOption = db.PupilOptions.Find(id);
            if (pupilOption == null)
            {
                return HttpNotFound();
            }
            return View(pupilOption);
        }

        // POST: PupilOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PupilOption pupilOption = db.PupilOptions.Find(id);
            db.PupilOptions.Remove(pupilOption);
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
