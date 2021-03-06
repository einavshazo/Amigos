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
    public class SchoolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Schools
        public ActionResult Index()
        {
            var schools = db.Schools.Include(s => s.City);
            return View(schools.ToList());
        }

        // GET: Schools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return PartialView(school);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            return PartialView();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Street,Number,CityID")] School school)
        {
            if (ModelState.IsValid)
            {
                db.Schools.Add(school);
                db.SaveChanges();
                return PartialView("Success");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", school.CityID);
            return View(school);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", school.CityID);
            return PartialView(school);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Street,Number,CityID")] School school)
        {
            if (ModelState.IsValid)
            {
                db.Entry(school).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("Success");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", school.CityID);
            return View(school);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return PartialView(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "ID")] School school)
        {
             school = db.Schools.Find(school.ID);
            db.Schools.Remove(school);
            db.SaveChanges();
            return PartialView("Success");
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
