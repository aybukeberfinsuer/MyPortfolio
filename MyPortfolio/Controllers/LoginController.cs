using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MyPortfolioEntities db = new MyPortfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(Tbl_Admin model)
        {
            var value = db.Tbl_Admin.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if(value == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
            FormsAuthentication.SetAuthCookie(value.Email, false);
            Session["nameSurname"] = value.Name + " " + value.Surname;
            return RedirectToAction("Index", "Category");
            
		}
	}
}