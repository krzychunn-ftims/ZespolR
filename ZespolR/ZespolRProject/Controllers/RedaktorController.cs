using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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



        public ActionResult ViewTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            TestVersion a = db.TestVersion.Where(x => x.tv_t == test.t_id).First();
            var b = db.Question.Where(x => x.q_tv == a.tv_id).ToList();
            return View(b);
        }


        public ActionResult Delete(int id)
        {
            Test test = db.Test.Find(id);
            db.Test.Remove(test);
            db.SaveChanges();
            return RedirectToAction("MyTests");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            TestVersion a = db.TestVersion.Where(x => x.tv_t == test.t_id).First();
            var b = db.Question.Where(x => x.q_tv == a.tv_id).ToList();
            return View(b);
        }

    }
}