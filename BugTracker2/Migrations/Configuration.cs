namespace BugTracker2.Migrations
{
    using BugTracker2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugTracker2.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "ProjectManager"))
            {
                roleManager.Create(new IdentityRole { Name = "ProjectManager" });
            }

            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }

            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }

            var userManager = new UserManager<ApplicationUser>(
              new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "jcfields@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jcfields@Mailinator.com",
                    Email = "jcfields@Mailinator.com",
                    FirstName = "Caleb",
                    LastName = "Fields",
                    DisplayName = "JCFields"
                }, "Abc&123!");
            }

            if (!context.Users.Any(u => u.Email == "Submitter@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Submitter@Mailinator.com",
                    Email = "Submitter@Mailinator.com",
                    FirstName = "Sub",
                    LastName = "Mitter",
                    DisplayName = "Submitter"
                }, "Abc&123!");
            }

            if (!context.Users.Any(u => u.Email == "Developer@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Developer@Mailinator.com",
                    Email = "Developer@Mailinator.com",
                    FirstName = "Dev",
                    LastName = "Eloper",
                    DisplayName = "Developer"
                }, "Abc&123!");
            }

            if (!context.Users.Any(u => u.Email == "ProjectManager@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ProjectManager@Mailinator.com",
                    Email = "ProjectManager@Mailinator.com",
                    FirstName = "Project",
                    LastName = "Manager",
                    DisplayName = "Project Manager"
                }, "Abc&123!");
            }
            var adminId = userManager.FindByEmail("jcfields@Mailinator.com").Id;
            userManager.AddToRole(adminId, "Admin");

            var submitterId = userManager.FindByEmail("Submitter@Mailinator.com").Id;
            userManager.AddToRole(submitterId,"Submitter");

            var projectmanagerId = userManager.FindByEmail("ProjectManager@Mailinator.com").Id;
            userManager.AddToRole(projectmanagerId,"ProjectManager");

            var developerId = userManager.FindByEmail("Developer@Mailinator.com").Id;
            userManager.AddToRole(developerId, "Developer");
        }
    }
}
