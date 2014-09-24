using CSC440_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC440_Project.Controllers
{
    public class OccupationalGroupController : Controller
    {
        protected AppDbContext _context;

        public OccupationalGroupController()
        {
            _context = new AppDbContext();
        }

        // GET: OccupationalGroup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var group = _context.OccupationalGroups.FirstOrDefault(g => g.Id == id);

            return View(group);
        }
    }
}