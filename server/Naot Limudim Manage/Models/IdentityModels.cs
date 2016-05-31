
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Collections;

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
    }
}