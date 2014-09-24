using CSC440_Project.Attributes;
using CSC440_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSC440_Project.Modules;
using System.IO;

namespace CSC440_Project.Controllers
{
    [UserAuthorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(string filepath)
        {
            //we want to check here that the first file in the request is not null
            if (Request.Files[0] != null)
            {
                var file = Request.Files[0];

                //byte[] data = new byte[file.ContentLength];

                //Stream stream = new MemoryStream(data);

                ExcelParser.ProcessFile(file.InputStream);
            }

            ViewBag.Message = "Success!";

            return View("Index");
        }
    }
}