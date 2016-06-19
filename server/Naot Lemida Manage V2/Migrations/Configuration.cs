namespace Naot_Lemida_Manage_V2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Naot_Lemida_Manage_V2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Naot_Lemida_Manage_V2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.YearOfStudies.AddOrUpdate(y => y.Year, new YearOfStudy { Year = "לא רלוונטי" });
            context.Cities.AddOrUpdate(c => c.Name, new City { Name = "לא רלוונטי" });
            context.Schools.AddOrUpdate(new School { Name = "לא רלוונטי", Street = "", Number = 0, CityID =1 });
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("מנהל"))
            {
                var role = new IdentityRole();
                role.Name = "מנהל";
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("רכז"))
            {
                var role = new IdentityRole();
                role.Name = "רכז";
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("מורה"))
            {
                var role = new IdentityRole();
                role.Name = "מורה";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("תלמיד"))
            {
                var role = new IdentityRole();
                role.Name = "תלמיד";
                roleManager.Create(role);

            }
        }
    }
}
