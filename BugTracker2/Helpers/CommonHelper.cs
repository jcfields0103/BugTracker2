using Microsoft.AspNet.Identity;
using BugTracker2.Enumerations;
using BugTracker2.Models;
using System;
using System.Linq;
using System.Web;

namespace BugTracker2.Helpers
{
    public abstract class CommonHelper
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        protected UserRolesHelper RoleHelper = new UserRolesHelper();
        protected ProjectsHelper ProjectHelper = new ProjectsHelper();
        protected ApplicationUser CurrentUser = null;
        protected SystemRole CurrentRole = SystemRole.None;

        protected CommonHelper()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            if(userId != null)
                CurrentUser = db.Users.Find(userId);

            //"Submitter" ==> SystemRole.Submitter          
            var stringRole = RoleHelper.ListUserRoles(userId).FirstOrDefault();

            if (!string.IsNullOrEmpty(stringRole))
                CurrentRole = (SystemRole)Enum.Parse(typeof(SystemRole), stringRole);
        }
    }
}