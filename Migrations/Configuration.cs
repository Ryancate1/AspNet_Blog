namespace rcate_blog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using rcate_blog.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<rcate_blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(rcate_blog.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Mod"))
            {
                roleManager.Create(new IdentityRole { Name = "Mod" });
            }

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "ryan.cate@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ryan.cate@yahoo.com",
                    Email = "ryan.cate@yahoo.com",
                    FirstName = "Ryan",
                    LastName = "Cate",
                }, "Password1");
            }
            if (!context.Users.Any(u => u.Email == "rchapman@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "rchapman@coderfoundry.com",
                    Email = "rchapman@coderfoundry.com",
                    FirstName = "Ryan",
                    LastName = "Chapman",
                }, "Password1");
            }
            if (!context.Users.Any(u => u.Email == "mjaang@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "mjaang@coderfoundry.com",
                    Email = "mjaang@coderfoundry.com",
                    FirstName = "Mark",
                    LastName = "Jaang",
                }, "Password1");
            }
            var userId = userManager.FindByEmail("ryan.cate@yahoo.com").Id;
            userManager.AddToRole(userId, "Admin");
            var ModId1 = userManager.FindByEmail("rchapman@coderfoundry.com").Id;
            userManager.AddToRole(ModId1, "Mod");
            var ModId2 = userManager.FindByEmail("mjaang@coderfoundry.com").Id;
            userManager.AddToRole(ModId2, "Mod");

        }
    }
}
