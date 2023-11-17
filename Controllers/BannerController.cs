using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class BannerController : Controller
    {
        ELearningContext context = new ELearningContext();
        // GET: Banner
        public ActionResult Index()
        {
            var values = context.quadLinks.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult updateQuads(int id) 
        {
            var value = context.quadLinks.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult updateQuads(QuadLink quadLink)
        {
            var value = context.quadLinks.Find(quadLink.quadLinkID);
            value.Title = quadLink.Title;
            value.Description = quadLink.Description;
            value.Ikon = quadLink.Ikon;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}