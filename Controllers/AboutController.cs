using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            ViewBag.v = "Hakkımızda";
            ViewBag.v2 = "Hakkımızda";
            return View();
        }
    }
}