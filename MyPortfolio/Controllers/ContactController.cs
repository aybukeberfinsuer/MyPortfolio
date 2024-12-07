using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        MyPortfolioEntities db= new MyPortfolioEntities();
        public ActionResult Index()
        {
            var value= db.TblContacts.ToList();
            return View(value);
        }


        [HttpGet]
        public ActionResult Update(int id) {
        var value= db.TblContacts.Find(id);
            return View(value);        
        }
        
        [HttpPost]
        public ActionResult Update(TblContact model) {
            var value = db.TblContacts.Find(model.ContactId);
            if(ModelState.IsValid)
            {
                value.Email=model.Email;
                value.Phone=model.Phone;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

			return View(model);

		}
    }
}