using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult InstructorPanelPartial()
        {
            string value = Session["CurrentMail"].ToString();
            int instructorId = context.Instructors.Where(x=>x.Email == value).Select(y=>y.InstructorID).FirstOrDefault();
            int id = instructorId;
            string instructorName = context.Instructors.Where(x=>x.Email==value).Select(y=>y.Name).FirstOrDefault();
            string instructorSurname = context.Instructors.Where(x=>x.Email==value).Select(y=>y.Surname).FirstOrDefault();
			var v1 = context.Instructors.Where(x => x.Name == instructorName && x.Surname == instructorSurname).Select(y => y.InstructorID).FirstOrDefault();
			var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();
			var values = context.Instructors.Where(x => x.InstructorID == id).ToList();
			ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == 2).Count();
			ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();
			return PartialView(values);
        }

        public PartialViewResult CommentPartial()
        {
            string value = Session["CurrentMail"].ToString();
            string instructorName = context.Instructors.Where(x => x.Email == value).Select(y => y.Name).FirstOrDefault();
            string instructorSurname = context.Instructors.Where(x => x.Email == value).Select(y => y.Surname).FirstOrDefault();

            var v1 = context.Instructors.Where(x => x.Name == instructorName && x.Surname == instructorSurname).Select(y => y.InstructorID).FirstOrDefault();
            var v2 = context.Courses.Where(x=>x.InstructorID==v1).Select(y=>y.CourseID).ToList();
            var v3 = context.Comments.Where(x=>v2.Contains(x.CourseID)).ToList();
            
            
			return PartialView(v3);
        }
        public PartialViewResult CourseListByInstructor()
        {
            string value = Session["CurrentMail"].ToString();
            int instructorId = context.Instructors.Where(x => x.Email == value).Select(y => y.InstructorID).FirstOrDefault();

            var values = context.Courses.Where(x=>x.InstructorID==instructorId).ToList();
            return PartialView(values);
		}
        [HttpGet]
        public ActionResult AddCourseVideo(int id)
        {
            
            var value = context.Courses.Find(id);
            var courseTitle = context.Courses.Where(x => x.CourseID == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.CourseID = id;
            ViewBag.CourseTitle = courseTitle;
            return View();
        }
        [HttpPost]
        public ActionResult AddCourseVideo (CourseLink courseLink)
        {
            context.CourseLinks.Add(courseLink);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}