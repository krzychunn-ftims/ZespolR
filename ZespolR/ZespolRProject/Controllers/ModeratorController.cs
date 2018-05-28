using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZespolRProject.Models;

namespace ZespolRProject.Controllers
{

    public class ModeratorController : Controller
    {
        private ZespolREntities db = new ZespolREntities();
        // GET: Moderator
        public ActionResult Index()
        {
            var i = int.Parse(System.Web.HttpContext.Current.User.Identity.Name);
            var t = db.Editor.Where(e => e.ed_mod == i).ToList();

            return View(t);

        }

        public ActionResult Requests()
        {
            return View();
        }
    }
}