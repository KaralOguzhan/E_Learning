using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyElearningProject.Controllers
{
    public class LoginController : Controller
    {
        ELearningContext context = new ELearningContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(Student student, Instructor instructor)
		{
            var values = context.Students.FirstOrDefault(x=>x.Email == student.Email && x.Password == student.Password);
            var value = context.Instructors.FirstOrDefault(y => y.Email == instructor.Email && y.Password == instructor.Password);
            var variable = context.Admins.FirstOrDefault(a => a.Email == instructor.Email && a.Password == instructor.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"]=values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Profile");
            }
            if(value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Email, false);
                Session["CurrentMail"] = value.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "InstructorAnalysis");
            }
            if (variable != null)
            {
                FormsAuthentication.SetAuthCookie(variable.Email, false);
                Session["CurrentMail"] = variable.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Student");
            }
            return View();
		}
      
	}
}