using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZespolR.Controllers
{
    public class RedaktorController : Controller
    {
        // GET: Redaktor
        public ActionResult Index()
        {
            return View();
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