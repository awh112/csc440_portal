using CSC440_Project.Attributes;
using CSC440_Project.Models;
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
        //this isn't what the partial view uses so we need to authorize it
        [UserAuthorize]
        public ActionResult Index()
        {
            var model = _context.OccupationalGroups.ToList();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var group = _context.OccupationalGroups.FirstOrDefault(g => g.Id == id);

            return View(group);
        }

        [UserAuthorize]
        public ActionResult Edit(int id)
        {
            var group = _context.OccupationalGroups.FirstOrDefault(g => g.Id == id);

            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(OccupationalGroup group)
        {
            if(ModelState.IsValid)
            {
                _context.SaveOccupationalGroup(group);
            }

            return View(group);
        }

        [UserAuthorize]
        public ActionResult Delete(int id)
        {
            OccupationalGroup deletedGroup = _context.DeleteOccupationalGroup(id);

            if(deletedGroup != null)
            {
                //display a message about it
            }

            return RedirectToAction("Index");
        }
    }
}