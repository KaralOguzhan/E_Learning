using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class DefaultController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialInstructor()
        {
            var values = context.Instructors.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialQuadLinks() 
        {
            var values = context.quadLinks.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialHomepageSecondPart()
        {
            return PartialView();
        }
        public PartialViewResult PartialHomepageCategories()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialPopularCourses()
        {
            var values = context.Courses.ToList();
            return PartialView(values);
        }
    }
}