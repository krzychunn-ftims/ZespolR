using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZespolRProject.Models;

namespace ZespolRProject.Controllers
{
    public class QuestionController : Controller
    {
        private ZespolREntities db = new ZespolREntities();

        // GET: Question
        public ActionResult Index()
        {
            var question = db.Question.Include(q => q.QuestionType).Include(q => q.TestVersion);
            return View(question.ToList());
        }

        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            ViewBag.q_qt = new SelectList(db.QuestionType, "qt_id", "qt_name");
            ViewBag.q_tv = new SelectList(db.TestVersion, "tv_id", "tv_id");
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "q_id,q_head,q_body,q_qt,q_is_neg,q_max_score,q_tv,q_answer,q_comment")] Question question)
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

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.q_qt = new SelectList(db.QuestionType, "qt_id", "qt_name", question.q_qt);
            ViewBag.q_tv = new SelectList(db.TestVersion, "tv_id", "tv_id", question.q_tv);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "q_id,q_head,q_body,q_qt,q_is_neg,q_max_score,q_tv,q_answer,q_comment")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.q_qt = new SelectList(db.QuestionType, "qt_id", "qt_name", question.q_qt);
            ViewBag.q_tv = new SelectList(db.TestVersion, "tv_id", "tv_id", question.q_tv);
            return View(question);
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Question.Find(id);
            db.Question.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
