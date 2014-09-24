using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CSC440_Project.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using CSC440_Project.Modules;

namespace CSC440_Project.Attributes
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUserId = httpContext.User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AppDbContext()));
            var currentUser = manager.FindById(currentUserId);

            if (currentUser != null)
            {
                if (currentUser.IsAdmin)
                {
                    return true;
                }

                return false;
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}