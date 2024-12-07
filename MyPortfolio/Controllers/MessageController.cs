using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MyPortfolioEntities db= new MyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblMessages.Where(m => m.IsRead == false).ToList();
            return View(values);
        }

        public PartialViewResult Details(int? id) {

            var value = db.TblMessages.Find(id);
            value.IsRead = true;
            db.SaveChanges();           
            return PartialView(value);
        }

        [HttpPost]
        public ActionResult MarkMessageRead(int id)
        {
            var value=db.TblMessages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ReadMessages()
        {
            var value=db.TblMessages.Where(x=>x.IsRead == true).ToList();
            return View(value);
        }
    }
}