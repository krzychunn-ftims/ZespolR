using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZespolRProject.Models;

namespace ZespolRProject.Controllers
{
    public class RedaktorController : Controller
    {
        private ZespolREntities db = new ZespolREntities();
        // GET: Redaktor
        public ActionResult MyTests()
        {
            
            return View(db.Test.ToList());
        }

        public ActionResult CreateTest()
        {
            ViewBag.Message = "Create Test page.";

            return View();
        }

        public ActionResult TestScore()
        {
            ViewBag.Message = "TestScore page.";

            return View();
        }
    }
}