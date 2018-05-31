using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            var a = db.Editor.Where(x => x.ed_isActive == null).ToList();
            return View(db.Editor.Where(x => x.ed_isActive == null).ToList());
        }

        public ActionResult details(int? id)
        {

            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Editor editor = db.Editor.Find(id);
                if (editor == null)
                {
                    return HttpNotFound();
                }

                return View(editor);
            }
        }

        public ActionResult t1()
        {
            return View(db.Editor.Where(x => x.ed_isActive == null).ToList());

        }

    }
}