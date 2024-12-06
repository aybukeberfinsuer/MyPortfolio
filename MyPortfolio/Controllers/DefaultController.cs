using MyPortfolio.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyPortfolioEntities db= new MyPortfolioEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultBanner()
        {
            var values=db.TblBanners.Where(x=>x.IsShown==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultSocialMedia()
        {
            var values = db.TblSocialMedias.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultExperties()
		{
			var values = db.TblExpertises.ToList();
			return PartialView(values);
		}

        public PartialViewResult DefaultExperience()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultEducation()
        {
            var values=db.TblEducations.ToList();  
            return PartialView(values);
        }

        public PartialViewResult DefaultProjects()
        {
            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
		[HttpPost]
		public ActionResult SendMessage(TblMessage model)
		{
            model.IsRead = false;
            db.TblMessages.Add(model);
            db.SaveChanges();
			return RedirectToAction("Index");
		}

        public PartialViewResult DefaultAbout()
        {
            var values=db.TblAbouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonial()
        {
            var values=db.TblTestimonials.ToList();
            return PartialView(values);
        }
        


	}
}