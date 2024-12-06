using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        MyPortfolioEntities db= new MyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblSocialMedias.ToList();
            return View(values);
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(TblSocialMedia social_model)
		{
			db.TblSocialMedias.Add(social_model);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
        {
            var value= db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


		[HttpGet]
		public ActionResult Update(int id)
		{
			var socialMedia = db.TblSocialMedias.Find(id);
			return View(socialMedia);
		}

		[HttpPost]
		public ActionResult Update(TblSocialMedia model)
		{
			var value = db.TblSocialMedias.Find(model.SocialMediaId);
			value.Name = model.Name;
			value.Url = model.Url;			
			db.SaveChanges();
			return RedirectToAction("Index");
		}



	}
}