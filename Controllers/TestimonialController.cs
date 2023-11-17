using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class TestimonialController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
         
        public ActionResult DeleteTestimonial(int id) 
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
		[HttpGet]
        public ActionResult AddTestimonial() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial) 
        { 
            var values = context.Testimonials.Find(testimonial.TestimonialID);
            values.NameSurname = testimonial.NameSurname;
            values.Status = testimonial.Status;
            values.ImageUrl = testimonial.ImageUrl;
            values.Comment = testimonial.Comment;
            values.Title = testimonial.Title;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
		//[HttpGet]
		public ActionResult Degistir(int id)
		{
			var value = context.Testimonials.Find(id);
            value.Status = !value.Status;
            context.SaveChanges();
			return RedirectToAction("Index");
		}
		//[HttpPost]
		//public ActionResult Degistir(Testimonial testimonial)
		//{
  //          var value = context.Testimonials.Find(testimonial.TestimonialID);
  //          value.Status = !value.Status;
  // ////         if(value.Status == true)
  // ////         {
		//	////	value.NameSurname = value.NameSurname;
				
		//	////	value.ImageUrl = value.ImageUrl;
		//	////	value.Comment = value.Comment;
		//	////	value.Title = value.Title;
		//	////	value.Status = false;
		//	////	context.SaveChanges();
				
		//	////}
  // ////         if(value.Status == false)
  // ////         {
  // ////             value.Status = true;
		//	////	context.SaveChanges();
				
		//	////}
  //          return RedirectToAction("Index");

		//}
	}

}