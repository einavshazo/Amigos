using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Naot_Lemida_Manage_V2.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Naot_Lemida_Manage_V2.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(r => r.Roles).Include(s => s.School).Include(y => y.YearOfStudy).OrderBy(r=>r.Name);
            return View(users.ToList());
        }


        // GET: Cities/Details/5
        public ActionResult Details(String id)
        {
            if (id==null||id.Equals(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView(user);
        }

        
        // GET: Cities/Edit/5
        public ActionResult Edit(String id)
        {
            if (id == null || id.Equals(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolID= new SelectList(db.Schools, "ID", "Name", user.SchoolID);
            ViewBag.IdentityRoleID = new SelectList(db.Roles, "ID", "Name", user.IdentityRoleID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "ID", "Year", user.YearOfStudyID);
            return PartialView(user);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name, LastName,Phone, Mail, SchoolID, IdentityRoleID, YearOfStudyID")]ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                ApplicationUser Model = UserManager.FindById(user.Id);
                Model.Name = user.Name;
                Model.LastName = user.LastName;
                Model.Phone = user.Phone;
                Model.Mail = user.Mail;
                Model.SchoolID = user.SchoolID;
                Model.IdentityRoleID = user.IdentityRoleID;
                Model.YearOfStudyID = user.YearOfStudyID;
                IdentityResult result = await UserManager.UpdateAsync(Model);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView(user);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(String id)
        {
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser Model = UserManager.FindById(id);
            IdentityResult result = await UserManager.DeleteAsync(Model);
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