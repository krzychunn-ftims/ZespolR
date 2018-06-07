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
    public class EditorsController : Controller
    {
        private ZespolREntities db = new ZespolREntities();

        // GET: Editors
        public ActionResult Index()
        {
            var editor = db.Editor.Include(e => e.Moderator);
            return View(editor.ToList());
        }

        // GET: Editors/Details/5
        public ActionResult Details(int? id)
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

        // GET: Editors/Create
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

        // GET: Editors/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name", editor.ed_mod);
            return View(editor);
        }

        // POST: Editors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ed_id,ed_name,ed_surname,ed_phone,ed_def_lng,ed_password,ed_mod,ed_isActive")] Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name", editor.ed_mod);
            return View(editor);
        }

        // GET: Editors/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Editors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editor editor = db.Editor.Find(id);
            db.Editor.Remove(editor);
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
