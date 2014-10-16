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

        public ActionResult Details(int id)
        {
            var group = _context.DetailedOccupations.FirstOrDefault(g => g.Id == id);

            return View(group);
        }

        [UserAuthorize]
        public ActionResult Edit(int id)
        {
            var group = _context.DetailedOccupations.FirstOrDefault(g => g.Id == id);

            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(DetailedOccupation occupation)
        {
            if (ModelState.IsValid)
            {
                _context.SaveDetailedOccupation(occupation);
            }

            return View(occupation);
        }

        [UserAuthorize]
        public ActionResult Delete(int id)
        {
            DetailedOccupation deletedGroup = _context.DeleteDetailedOccupation(id);

            if (deletedGroup != null)
            {
                //display a message about it
            }

            return RedirectToAction("Index");
        }
    }
}