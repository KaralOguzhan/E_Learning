using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class HomepageCoursesController : Controller
    {
        // GET: HomepageCourses
        public ActionResult Index()
        {
            ViewBag.v = "Kurslar";
            return View();
        }
    }
}