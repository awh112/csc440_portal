using CSC440_Project.Attributes;
using CSC440_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC440_Portal.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [UserAuthorize]
        public ActionResult Index()
        {
            var context = new AppDbContext();
            var users = context.Users.ToList();
            return View(users);
        }
    }
}