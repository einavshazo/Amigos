
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Naot_Lemida_Manage_V2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Display(Name = "שם")]
        public String Name { get; set; }

        [Display(Name = "שם משפחה")]
        public String LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "נייד")]
        public String Phone { get; set; }

        [Display(Name = "כיתה")]
        public int YearOfStudyID { get; set; }
        public virtual YearOfStudy YearOfStudy { get; set; }

        [EmailAddress]
        [Display(Name = "מייל")]
        public String Mail { get; set; }

        [Display(Name = "מוסד")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }

        [Display(Name = "תפקיד")]
        public String IdentityRoleID { get; set; }
        public virtual IdentityRole IdentityRole { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public static DataTable getManagersTable()
        {
            DataTable table = new DataTable("מנהלים");
            table.Columns.Add("שם משתמש",typeof(string));
            table.Columns.Add("שם פרטי", typeof(string));
            table.Columns.Add("שם משפחה", typeof(string));

            ApplicationDbContext db = new ApplicationDbContext();
            var managers= db.Users.Include(u=>u.Roles).Where(u=>u.IdentityRole.Name.Equals("מנהל")).ToList();
            foreach(var manager in managers)
            {
                table.Rows.Add(manager.Email, manager.Name, manager.LastName);
            }
            return table;
        }
        public static DataTable getCoordinatorsTable()
        {
            DataTable table = new DataTable("רכזים");
            table.Columns.Add("שם משתמש", typeof(string));
            table.Columns.Add("שם פרטי", typeof(string));
            table.Columns.Add("שם משפחה", typeof(string));
            table.Columns.Add("נייד", typeof(string));
            table.Columns.Add("שם המוסד", typeof(string));

            ApplicationDbContext db = new ApplicationDbContext();
            var coordinators = db.Users.Include(u => u.Roles).Include(s=>s.School).Where(u => u.IdentityRole.Name.Equals("רכז")).ToList();
            foreach (var coordinator in coordinators)
            {
                table.Rows.Add(coordinator.Email, coordinator.Name, coordinator.LastName,coordinator.Phone,coordinator.School.Name);
            }
            return table;
        }
        public static DataTable getTeachersTable()
        {
            DataTable table = new DataTable("מורים");
            table.Columns.Add("שם משתמש", typeof(string));
            table.Columns.Add("שם פרטי", typeof(string));
            table.Columns.Add("שם משפחה", typeof(string));
            table.Columns.Add("נייד", typeof(string));
            table.Columns.Add("מייל", typeof(string));
            table.Columns.Add("שם המוסד", typeof(string));

            ApplicationDbContext db = new ApplicationDbContext();
            var teachers = db.Users.Include(u => u.Roles).Where(u => u.IdentityRole.Name.Equals("מורה")).ToList();
            foreach (var teacher in teachers)
            {
                table.Rows.Add(teacher.Email, teacher.Name, teacher.LastName, teacher.Phone,teacher.Mail, teacher.School.Name);
            }
            return table;
        }
        public static DataTable getPupilsTable()
        {
            DataTable table = new DataTable("תלמידים");
            table.Columns.Add("שם משתמש", typeof(string));
            table.Columns.Add("שם פרטי", typeof(string));
            table.Columns.Add("שם משפחה", typeof(string));
            table.Columns.Add("נייד", typeof(string));
            table.Columns.Add("שם המוסד", typeof(string));
            table.Columns.Add("כיתה", typeof(string));

            ApplicationDbContext db = new ApplicationDbContext();
            var pupils = db.Users.Include(u => u.Roles).Where(u => u.IdentityRole.Name.Equals("תלמיד")).ToList();
            foreach (var pupil in pupils)
            {
                table.Rows.Add(pupil.Email, pupil.Name, pupil.LastName, pupil.Phone, pupil.School.Name,pupil.YearOfStudy.Year);
            }
            return table;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<School> Schools { get; set; }
        public System.Data.Entity.DbSet<YearOfStudy> YearOfStudies { get; set; }

        public System.Data.Entity.DbSet<City> Cities { get; set; }

        public System.Data.Entity.DbSet<Naot_Lemida_Manage_V2.Models.Option> Options { get; set; }
    }
}