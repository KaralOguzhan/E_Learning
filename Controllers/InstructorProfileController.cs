using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorProfileController : Controller
    {
        ELearningContext context =new ELearningContext();
        public ActionResult Index()
        {
            string values = Session["CurrentMail"].ToString();
            ViewBag.mail = Session["CurrentMail"];
            ViewBag.fullName = context.Instructors.Where(x=>x.Email==values).Select(x=>x.Name+ " " + x.Surname ).FirstOrDefault();
            ViewBag.ImgUrl = context.Instructors.Where(x=>x.Email==values).Select(x=>x.ImageUrl).FirstOrDefault();
            return View();
        }
    }
}