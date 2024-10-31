﻿using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CategoryController : Controller
    {
       MyPortfolioEntities db= new MyPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblCategories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCategory() {

            return View();

        }

        [HttpPost]
        public ActionResult CreateCategory(TblCategory category)
        {

            db.TblCategories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}