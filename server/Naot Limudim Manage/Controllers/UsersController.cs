using System;
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
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(r => r.Roles).Include(s => s.School).Include(y => y.YearOfStudy).OrderBy(r=>r.IdentityRoleID);
            return View(users.ToList());
        }

    }
}