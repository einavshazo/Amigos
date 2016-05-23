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
    public class TeacherOptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherOptions
        public ActionResult Index()
        {
            var teacherOptions = db.TeacherOptions.Include(t => t.Teacher);
            return View(teacherOptions.ToList());
        }

        // GET: TeacherOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherOption teacherOption = db.TeacherOptions.Find(id);
            if (teacherOption == null)
            {
                return HttpNotFound();
            }
            return View(teacherOption);
        }

        // GET: TeacherOptions/Create
        public ActionResult Create()
        {
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name");
            return View();
        }

        // POST: TeacherOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Start,End,TeacherID")] TeacherOption teacherOption)
        {
            if (ModelState.IsValid)
            {
                db.TeacherOptions.Add(teacherOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", teacherOption.TeacherID);
            return View(teacherOption);
        }

        // GET: TeacherOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherOption teacherOption = db.TeacherOptions.Find(id);
            if (teacherOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", teacherOption.TeacherID);
            return View(teacherOption);
        }

        // POST: TeacherOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Start,End,TeacherID")] TeacherOption teacherOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", teacherOption.TeacherID);
            return View(teacherOption);
        }

        // GET: TeacherOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherOption teacherOption = db.TeacherOptions.Find(id);
            if (teacherOption == null)
            {
                return HttpNotFound();
            }
            return View(teacherOption);
        }

        // POST: TeacherOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherOption teacherOption = db.TeacherOptions.Find(id);
            db.TeacherOptions.Remove(teacherOption);
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
