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
            QuestionCollection q1 = new QuestionCollection();
            q1.Models = question.ToList();
            q1.testID = id.Value;
            return View(q1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TestTake( QuestionCollection question)
        {
            if (ModelState.IsValid)
            {
                for(int i=0; i<question.Models.Count;i++)
                {
                    
                    Answ answer = new Answ();
                    answer.a_test = question.testID;
                    answer.a_ques = question.Models[i].q_id;
                    answer.a_answ = question.Models[i].q_comment;
                    answer.a_user = true;
                    answer.a_cand = 1;
                    db.Answ.Add(answer);
                    db.SaveChanges();
                }
                return RedirectToAction("Candidate1");
            }
            return View(question);
        }

    }
}