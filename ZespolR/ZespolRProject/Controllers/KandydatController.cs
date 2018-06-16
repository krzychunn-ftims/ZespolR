using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZespolRProject.Models;

 

namespace ZespolRProject.Controllers
{
    public class KandydatController : Controller
    {



        private ZespolREntities db = new ZespolREntities();
        // GET: Moderator
        public ActionResult Candidate1()
        {

            List<Test> list = db.Test.ToList();
            List<Editor> list2 = db.Editor.ToList();

            TestsCollection a = new TestsCollection();
            EditorsCollection b = new EditorsCollection();

            Editor_Test c = new Editor_Test();

            foreach (Test item in list)
            {
                c.Tests.Models.Add(item);
            }

            c.Editors.Models = new List<Editor>();
            foreach (Editor item in list2)
            {
                c.Editors.Models.Add(item);
            }

            return View(c);

        }
        // GET: Candidate
        //public ActionResult Candidate1()
        //{
        //    return View();
        //}

        public ActionResult Candidate2()
        {
            return View();
        }

        //public ActionResult TestTake(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Question question = db.Question.Find(id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(question);
        //}
        public ActionResult TestTake(int? id)
        {
            var question = db.Question.Include(q => q.QuestionType).Include(q => q.TestVersion).Where(x=>x.q_tv==id);
            return View(question.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TestTake([Bind(Include = "q_body")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.q_qt = new SelectList(db.QuestionType, "qt_id", "qt_name", question.q_qt);
            ViewBag.q_tv = new SelectList(db.TestVersion, "tv_id", "tv_id", question.q_tv);
            return View(question);
        }

    }
}