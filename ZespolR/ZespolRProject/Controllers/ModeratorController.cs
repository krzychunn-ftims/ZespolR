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

        public ActionResult Create()
        {
            ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name");
            return View();
        }

        // POST: Editors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ed_id,ed_name,ed_surname,ed_phone,ed_def_lng,ed_password,ed_mod,ed_isActive")] Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Editor.Add(editor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name", editor.ed_mod);
            return View(editor);
        }
    }
}