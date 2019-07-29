namespace CodeGeist2019.Migrations
{
    using CodeGeist2019.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeGeist2019.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeGeist2019.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            string roleName1 = "Writer";
            string roleName2 = "Designer";
            string roleName3 = "Translator";
            IdentityResult roleResult;

            if (!RoleManager.RoleExists(roleName1))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleName1));
            }

            if (!RoleManager.RoleExists(roleName2))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleName2));
            }

            if (!RoleManager.RoleExists(roleName3))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleName3));
            }
        }
    }
}
