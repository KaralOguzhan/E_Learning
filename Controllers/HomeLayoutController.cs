using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class HomeLayoutController : Controller
    {
        // GET: HomeLayout
        public ActionResult Index()
        {
            return View();
        }
    }
}