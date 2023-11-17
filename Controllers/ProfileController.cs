using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ProfileController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            string values = Session["CurrentMail"].ToString();

			ViewBag.mail = Session["CurrentMail"];
            ViewBag.name = context.Students.Where(x=>x.Email==values).Select(y=>y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.ImgUrl = context.Students.Where(x => x.Email == values).Select(y => y.ImgUrl).FirstOrDefault();
            ViewBag.id = context.Students.Where(x => x.Email == values).Select(x => x.StudentID).FirstOrDefault();
            return View();
        }
        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var value = context.Students.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProfile(Student student)
        {
            var value = context.Students.Find(student.StudentID);
            value.Name = student.Name;
            value.Surname = student.Surname;
            value.Email = student.Email;
            value.Password = student.Password;
            context.SaveChanges();
            

            return RedirectToAction("Index", "Profile");
        }
        public ActionResult MyCourseList() 
        {
			string values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x=>x.Email==values).Select(y=>y.StudentID).FirstOrDefault();
            var courseList = context.Processes.Where(x=>x.StudentID==id).ToList();
			return View(courseList);
        }
        [HttpGet]
        public ActionResult RateCourse(int id)
        {
            var values = context.Courses.Find(id);
            var courseTitle = context.Courses.Where(x => x.CourseID == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.courseName = courseTitle.ToString();
            ViewBag.v = id;


            return View();
        }
        [HttpPost]
        
        public ActionResult RateCourse(Review review)
        {

            var email = Session["CurrentMail"];

            var studentID = context.Students.Where(x => x.Email == email.ToString()).Select(x => x.StudentID).FirstOrDefault();
            var searchReasult = context.Reviews.Where(w => w.StudentID == studentID);

            


            //if (searchReasult.Any())
            {
            review.StudentID = studentID;
            context.Reviews.AddOrUpdate(review);

            context.SaveChanges();
            return RedirectToAction("Index", "Profile");
            }
           //else
          //  {
            //    review.StudentID = studentID;
            //    context.Reviews.Add(review);

            //    context.SaveChanges();
            //    return RedirectToAction("Index", "Profile");
            //}
            
        }
        [HttpGet]
        public ActionResult CommentCourse(int id)
        {
            var values = context.Courses.Find(id);
            var courseTitle = context.Courses.Where(x => x.CourseID == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.courseName = courseTitle.ToString();
            ViewBag.v = id;


            return View();
        }
        [HttpPost]
        public ActionResult CommentCourse(Comment comment)
        {
            var email = Session["CurrentMail"];

            var studentID = context.Students.Where(x => x.Email == email.ToString()).Select(x => x.StudentID).FirstOrDefault();
            comment.StudentID = studentID;
            comment.CommentStatus = true;
            comment.CommentDate = DateTime.Now;
            context.Comments.Add(comment);

            context.SaveChanges();
            return RedirectToAction("Index", "Profile");

            
        }
        public ActionResult WatchCourse(int id) 
        {

            var CourseId = context.Courses.Find(id);
            ViewBag.course = id;
            ViewBag.C = context.Courses.Where(c => c.CourseID == id).Select(y => y.Title).FirstOrDefault();
            var value = context.CourseLinks.ToList();
            return View(value);
        }



    }
}