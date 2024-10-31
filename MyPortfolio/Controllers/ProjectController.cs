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

        public ActionResult Index()
        {
            var projects = db.TblProjects.ToList();
            return View(projects);
        }
    }
}