using CSC440_Project.Attributes;
using CSC440_Project.Models;
using CSC440_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC440_Portal.Controllers
{
    [UserAuthorize]
    public class UserController : Controller
    {
        protected AppDbContext _context;

        public UserController()
        {
            _context = new AppDbContext();
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public ActionResult Edit(string id)
        {
            var user = _context.Users.ToList().FirstOrDefault(u => u.Id == id);
            return View();
        }

        public ActionResult Delete(string id)
        {
            var user = _context.Users.ToList().FirstOrDefault(u => u.Id == id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                _context.SaveUser(user);
            }

            return View(user);
        }
    }
}