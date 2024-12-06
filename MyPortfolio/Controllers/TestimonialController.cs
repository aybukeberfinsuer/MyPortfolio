using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        MyPortfolioEntities db= new MyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(TblTestimonial model, HttpPostedFileBase ImageFile)
		{
			if (ModelState.IsValid)
			{
				if (model.ImageFile != null)
				{
					var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
					var saveLocation = currentDirectory + "images\\";
					var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
					model.ImageFile.SaveAs(fileName);
					model.ImageUrl = "/images/" + model.ImageFile.FileName;
				}
				db.TblTestimonials.Add(model);
				db.SaveChanges();
				
				return RedirectToAction("Index");
			}
			return View(model);
		}



		public ActionResult Delete(int id) {
			
				var delete_value = db.TblTestimonials.Find(id);
				db.TblTestimonials.Remove(delete_value);
				db.SaveChanges();
				return RedirectToAction("Index");
			
		}


		[HttpGet]
		public ActionResult Update(int id)
		{
			var testimonial = db.TblTestimonials.Find(id);
			return View(testimonial);
		}

		[HttpPost]
		public ActionResult Update(TblTestimonial model, HttpPostedFileBase ImageFile)
		{
			var value = db.TblTestimonials.Find(model.TestimonialId);
			if (ModelState.IsValid)
			{
				if (model.ImageFile != null)
				{
					var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
					var saveLocation = currentDirectory + "images\\";
					var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
					model.ImageFile.SaveAs(fileName);
					model.ImageUrl = "/images/" + model.ImageFile.FileName;
				}
				value.NameSurname = model.NameSurname;
				value.ImageUrl= model.ImageUrl;
				value.Title=model.Title;
				value.Comment=model.Comment;
				db.SaveChanges();

				return RedirectToAction("Index");
			}
			return View(model);
		}
	}
}





