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

    public class ModeratorController : Controller
    {
        private ZespolREntities db = new ZespolREntities();
        // GET: Moderator
        public ActionResult Index()
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

        public ActionResult Requests()
        {

            //var a = db.Editor.Where(x => x.ed_isActive == null).ToList();
            return View(db.Users.Where(x=>x.isEditor==true && x.isActivated!=true));
        }

        public ActionResult Position()
        {
            return View(db.Position.ToList());
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

        public ActionResult details2( )
        {

            return View(db.Editor.Where(x => x.ed_isActive == null).ToList());
        }


        public ActionResult t1()
        {
            return View(db.Editor.Where(x => x.ed_isActive == null).ToList());

        }

        public ActionResult CreateRedaktor()
        {
            //ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name");
            return View();
        }

        // POST: Editors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ed_id,ed_name,ed_surname,ed_phone,ed_def_lng,ed_password,ed_mod,ed_isActive")] Editor editor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Editor.Add(editor);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //public ActionResult Addnew()
        //{
        //    return View();
        //}

        // GET: Editors/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name");
        //    return View();
        //}

        // POST: Editors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRedaktor([Bind(Include = "email,password,")] Users users)
        {
            if (ModelState.IsValid)
            {
                users.isEditor = true;
                users.isActivated = true;
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }


        //GET: Editors/Edit/5
        public ActionResult EditRedaktor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users editor = db.Users.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name", editor.ed_mod);
            return View(editor);
        }

        // POST: Editors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRedaktor([Bind(Include = "user_id,email,isActivated,password")] Users editor)
        {
            if (ModelState.IsValid)
            {
                editor.isEditor = true;
                db.Entry(editor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Requests");
            }
            //ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name", editor.ed_mod);
            return View(editor);
        }

        // GET: Editors/Delete/5
        public ActionResult DeleteRedaktor(int? id)
        {
            Users question = db.Users.Find(id);
            int? presId = question.user_id;
            db.Users.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Requests");
        }

        //// POST: Editors/Delete/5
        //[HttpPost, ActionName("DeleteRedaktor")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Users editor = db.Users.Find(id);
        //    db.Users.Remove(editor);
        //    db.SaveChanges();
        //    return RedirectToAction("Requests");
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Positions/Create
        public ActionResult CreatePosition()
        {
            return View();
        }

        // POST: Positions/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePosition([Bind(Include = "po_id,po_name,po_desc,po_isActive")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Position.Add(position);
                db.SaveChanges();
                return RedirectToAction("Position");
            }

            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult EditPosition(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Position.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPosition([Bind(Include = "po_id,po_name,po_desc,po_isActive")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Position");
            }
            return View(position);
        }





        // GET: Tests/Edit/5
        public ActionResult EditTest(int? id)
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
            ViewBag.t_ed = new SelectList(db.Editor, "ed_id", "ed_name", test.t_ed);
            ViewBag.t_po = new SelectList(db.Position, "po_id", "po_name", test.t_po);
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTest([Bind(Include = "t_id,t_name,t_desc,t_po,t_def_lng,t_ed,t_start,t_end,t_is_published,t_tt_limit,t_pass_limit,t_time_limit")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.t_ed = new SelectList(db.Editor, "ed_id", "ed_name", test.t_ed);
            ViewBag.t_po = new SelectList(db.Position, "po_id", "po_name", test.t_po);
            return View(test);
        }


        // GET: Tests/Delete/5
        public ActionResult DeleteTest(int? id)
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
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("DeleteTest")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTestConfirmed(int id)
        {
            Test test = db.Test.Find(id);
            db.Test.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

 



    }


        
    
}