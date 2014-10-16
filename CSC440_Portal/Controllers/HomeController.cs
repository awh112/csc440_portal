using CSC440_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC440_Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string sortType)
        {
            var context = new AppDbContext();

            var groups = context.OccupationalGroups.ToList();

            switch(sortType)
            {
                case "GroupName":
                    groups = groups.OrderBy(g => g.GroupName).ToList();
                    break;
                case "Current":
                    groups = groups.OrderByDescending(g => g.CurrentEmploymentNumber).ToList();
                    break;
                case "Future":
                    groups = groups.OrderByDescending(g => g.FutureEmploymentNumber).ToList();
                    break;
                case "Change":
                    groups = groups.OrderByDescending(g => g.PercentChange).ToList();
                    break;
                default:
                    break;
            }

            return View(groups);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}