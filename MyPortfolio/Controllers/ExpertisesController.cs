using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExpertisesController : Controller
    {
        // GET: Expertises
        MyPortfolioEntities db= new MyPortfolioEntities();
        public ActionResult Index()
        {
            var value = db.TblExpertises.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult Create() {
       return View();
        
        }
        [HttpPost]
        public ActionResult Create(TblExpertis model)
        {
            db.TblExpertises.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


		[HttpGet]
		public ActionResult Update(int id)
		{
            var value = db.TblExpertises.Find(id);
			return View(value);

		}
		[HttpPost]
		public ActionResult Update(TblExpertis model)
		{
            var value = db.TblExpertises.Find(model.ExpertiseId);
            value.Title=model.Title;
            db.SaveChanges();
            return RedirectToAction("Index");

		}

		public ActionResult Delete(int id)
        {
            var value = db.TblExpertises.Find(id);
            db.TblExpertises.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }



    }
}