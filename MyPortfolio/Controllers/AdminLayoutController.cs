﻿using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Layout()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSideBar() {
			var email = Session["email"].ToString();
			var admin = db.Tbl_Admin.FirstOrDefault(x => x.Email == email);

			ViewBag.nameSurname = admin.Name + " " + admin.Surname;
			ViewBag.image = admin.ImageUrl;
			return PartialView();

		}

        public PartialViewResult AdminLayoutNavbar() {
          
			var email = Session["email"].ToString();
			var admin = db.Tbl_Admin.FirstOrDefault(x => x.Email == email);

			ViewBag.nameSurname = admin.Name + " " + admin.Surname;
			ViewBag.image = admin.ImageUrl;
			var unreadMessages = db.TblMessages
								  .Where(m => (bool)!m.IsRead)
								  .OrderByDescending(m => m.DataSent)
								  .Take(3)
								  .ToList();

			return PartialView(unreadMessages);

		}

        public PartialViewResult AdminLayoutScripts() {
            return PartialView();

        }

        public PartialViewResult AdminLayoutFooter() {
            return PartialView();

        }
    }
}