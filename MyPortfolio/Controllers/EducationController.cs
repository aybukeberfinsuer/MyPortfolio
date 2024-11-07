using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class EducationController : Controller
    {
        MyPortfolioEntities db=new MyPortfolioEntities();
        public ActionResult Index()
        {
            var values=db.TblEducations.ToList();
            return View(values);
        }


        public ActionResult Delete(int id) {
            var delete_value= db.TblEducations.Find(id);
            db.TblEducations.Remove(delete_value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


      
    }
}