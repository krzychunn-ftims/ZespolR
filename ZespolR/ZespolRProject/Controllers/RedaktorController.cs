using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZespolRProject.Models;
using System.Data;
using System.Data.Entity;


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

        //public ActionResult CreateTest()
        //{
        //    ViewBag.Message = "Create Test page.";

        //    return View();
        //}

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
            //TestVersion a = db.TestVersion.Where(x => x.tv_t == test.t_id).First();
            var b = db.Question.Where(x => x.q_tv == id).ToList();
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


        public ActionResult DeleteQuestion(int id)
        {
            Question question = db.Question.Find(id);
            int? presId = question.q_tv;
            db.Question.Remove(question);
            db.SaveChanges();
            return RedirectToAction("ViewTest", new { id = presId });
        }

        // GET: Question/Create
        public ActionResult CreateQuestion(int? id)
        {

            ViewBag.q_qt = new SelectList(db.QuestionType, "qt_id", "qt_name");
            ViewBag.q_tv = new SelectList(db.TestVersion, "tv_id", "tv_id");
            ViewBag.ID = id;
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestion([Bind(Include = "q_id,q_head,q_body,q_tv,q_answer")] Question question)
        {
            if (ModelState.IsValid)
            {

                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("ViewTest", new { id = question.q_tv });
            }

            ViewBag.q_qt = new SelectList(db.QuestionType, "qt_id", "qt_name", question.q_qt);
            ViewBag.q_tv = new SelectList(db.TestVersion, "tv_id", "tv_id", question.q_tv);
            return View(question);
        }


        public ActionResult CreateTest()
        {
            ViewBag.t_ed = new SelectList(db.Editor, "ed_id", "ed_name");
            ViewBag.t_po = new SelectList(db.Position, "po_id", "po_name");
            return View();
        }

        // POST: Tests1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTest([Bind(Include = "t_id,t_name,t_desc,t_po,t_ed")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Test.Add(test);
                Question q1 = new Question();
                q1.q_head = "Example Question";
                q1.q_body = "Example Body";
                q1.q_tv = test.t_id;
                db.Question.Add(q1);
                db.SaveChanges();
                return RedirectToAction("MyTests");
            }

            ViewBag.t_ed = new SelectList(db.Editor, "ed_id", "ed_name", test.t_ed);
            ViewBag.t_po = new SelectList(db.Position, "po_id", "po_name", test.t_po);



            return View(test);
        }

    }
}