using CSC440_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC440_Portal.Controllers
{
    public class DetailedOccupationController : Controller
    {
        protected AppDbContext _context;

        public DetailedOccupationController()
        {
            _context = new AppDbContext();
        }

        // GET: DetailedOccupation
        public ActionResult Index()
        {
            var model = _context.DetailedOccupations.ToList();

            return View(model);
        }
    }
}