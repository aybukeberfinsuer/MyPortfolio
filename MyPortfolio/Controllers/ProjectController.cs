using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfolioEntities db= new MyPortfolioEntities();

        private void CategoryDropDown()
        {
			var categoryList = db.TblCategories.ToList();
			List<SelectListItem> categories = (from x in categoryList
											   select new SelectListItem
											   {
												   Text = x.Name,
												   Value = x.CategoryId.ToString(),
											   }).ToList();

			ViewBag.categories = categories;
		}

        public ActionResult Index()
        {
            var projects = db.TblProjects.ToList();
            return View(projects);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
			CategoryDropDown();
            return View();
        }


        [HttpPost]
        public ActionResult CreateProject(TblProject model) {
            CategoryDropDown();
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            db.TblProjects.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }

        public ActionResult DeleteProject(int id) {

            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var value = db.TblProjects.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject model)
        {
            CategoryDropDown();
            var value = db.TblProjects.Find(model.ProjectId);
            value.ImageUrl = model.ImageUrl;
            value.Description = model.Description;
            value.Name = model.Name;
            value.CategoryId = model.CategoryId;
            value.GithubUrl= model.GithubUrl;
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}