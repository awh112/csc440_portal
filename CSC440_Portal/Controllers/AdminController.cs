﻿using CSC440_Project.Attributes;
using CSC440_Project.Modules;
using Ionic.Zip;
using System.IO;
using System.Net;
using System.Web.Mvc;

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

        public ActionResult UploadCincy()
        {
            return View();
        }

        public ActionResult UploadBLS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SyncCincyData()
        {
            //this won't change for the purposes of this assignment
            string cincyURL = "http://d2fy1sc0f5svw4.cloudfront.net/Preset%20Tables%20Cincinnati%20MSA.zip";

            byte[] zipInfo = null;

            using(var wc = new WebClient())
            {
                zipInfo = wc.DownloadData(cincyURL);
            }

            if(zipInfo != null)
            {
                //get the stream from the byte info
                Stream zipStream = new MemoryStream(zipInfo);

                using(ZipFile zip = ZipFile.Read(zipStream))
                {
                    MemoryStream outputStream = new MemoryStream();

                    ZipEntry entry = zip[0];
                    entry.Extract(outputStream);

                    ExcelParser.ProcessODCFile(outputStream);
                }
            }

            ViewBag.Message = "Success!";

            return View("Index");
        }

        [HttpPost]
        public ActionResult SyncBLSData()
        {
            //this won't change for the purpose of this assignment
            string blsURL = "http://www.bls.gov/emp/ind-occ-matrix/occupation.xls";

            byte[] excelInfo = null;

            using(var wc = new WebClient())
            {
                excelInfo = wc.DownloadData(blsURL);
            }

            Stream stream = new MemoryStream(excelInfo);
            ExcelParser.ProcessBLSFile(stream);

            ViewBag.Message = "Success!";
            
            return View("Index");
        }
    }
}