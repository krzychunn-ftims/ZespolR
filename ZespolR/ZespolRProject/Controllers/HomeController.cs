using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZespolRProject.Models;

namespace ZespolRProject.Controllers
{
    public class HomeController : Controller
    {
        private ZespolREntities db = new ZespolREntities();

        public ActionResult Index()
        {
            var c = System.Web.HttpContext.Current.User.Identity.Name;
            return View();
        }

        public ActionResult Registered()
        {

            return View();
        }

        public ActionResult Logged()
        {
            var u = System.Web.HttpContext.Current.User.Identity.Name;
            var c = db.Users.Where(x => x.email == u).First();
            if (c.isAdmin == true)
            {
                return RedirectToAction("Index", "Moderator");
            }
            else if (c.isEditor ==true)
            {
                if(c.isActivated == true)
                {
                 return RedirectToAction("MyTests", "Redaktor");
                }
                else
                {
                 return RedirectToAction("Login", "Registration");
                }
            }
            else
                return RedirectToAction("Candidate1", "Kandydat");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}