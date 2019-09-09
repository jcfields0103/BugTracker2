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

            context.Projects.AddOrUpdate(p => p.Name,
                    new Project { Name = "Portfolio", Description = "My 1st Project, The Portfolio Website", Created = DateTime.Now },
                    new Project { Name = "My Blog", Description = "My 2nd Project, The Blog Website", Created = DateTime.Now },                    
                    new Project { Name = "Bug Tracker", Description = "My 3rd Project, The Bug Tracker Website", Created = DateTime.Now });
            context.TicketPriorities.AddOrUpdate(t => t.Name,
                    new TicketPriority { Name = "Immediate", Description = "Highest level, requires immediate action" },
                    new TicketPriority { Name = "High", Description = "High priority, requires quick action" },
                    new TicketPriority { Name = "Moderate", Description = "Medium priority, requires action" },
                    new TicketPriority { Name = "Low", Description = "Low priority, requires action once all other priorities are completed" },
                    new TicketPriority { Name = "None", Description = "No Action required" });
            context.TicketStatuses.AddOrUpdate(t => t.Name,
                    new TicketStatus { Name = "Unassigned", Description = "" },
                    new TicketStatus { Name = "New/Unassigned", Description = "" },
                    new TicketStatus { Name = "Assigned", Description = "" },
                    new TicketStatus { Name = "In Progress", Description = "" },
                    new TicketStatus { Name = "Completed", Description = "" },
                    new TicketStatus { Name = "Archived", Description = "" });
            context.TicketTypes.AddOrUpdate(t => t.Name,
                    new TicketType { Name = "Bug", Description = "An error has occured that resulted in either the application crashing or the user seeing error information" },
                    new TicketType { Name = "Defect", Description = "AN error has occured that resulted in either a miscalculation or an incorrect workflow" },
                    new TicketType { Name = "Feature Request", Description = "A client has asked for new functionality in an application" },
                    new TicketType { Name = "Documentation Request", Description = "A client has called in asking for new documentation to be created for the existing application" },
                    new TicketType { Name = "Training Request", Description = "Client Asking to schedule training session" },
                    new TicketType { Name = "Complaint", Description = "A client has called in to make a general complaint about the application" },
                    new TicketType { Name = "Other", Description = "A call ahas been recieved that requires a follow up but is outside normal paramaters for a request" });


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
