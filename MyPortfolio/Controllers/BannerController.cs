using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
	public class BannerController : Controller
	{
		MyPortfolioEntities db = new MyPortfolioEntities();

		
		public ActionResult Index()
		{
			var values = db.TblBanners.ToList();
			return View(values);
		}

		
		public ActionResult Show(int id)
		{
			
			var allBanners = db.TblBanners.ToList();
			foreach (var banner in allBanners)
			{
				banner.IsShown = false;
			}

			
			var selectedBanner = db.TblBanners.FirstOrDefault(b => b.BannerId == id);
			if (selectedBanner != null)
			{
				selectedBanner.IsShown = true;
				db.SaveChanges();
			}

			return RedirectToAction("Index");
		}

		// GET: Banner/Delete/5
		public ActionResult Delete(int id)
		{
			var value = db.TblBanners.Find(id);

			if (value != null)
			{
				
				int bannerCount = db.TblBanners.Count();

				if (bannerCount <= 1)
				{
					
					TempData["Message"] = "The last remaining banner cannot be deleted.";
					return RedirectToAction("Index");
				}

				db.TblBanners.Remove(value);
				db.SaveChanges();
			}

			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(TblBanner banner)
		{
			if (ModelState.IsValid)
			{
				var allBanners = db.TblBanners.ToList();
				foreach (var existingBanner in allBanners)
				{
					existingBanner.IsShown = false;
				}

				banner.IsShown = true;
				db.TblBanners.Add(banner);
				db.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(banner);
		}

	}
}
