﻿using System;
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
            return View(db.Editor.ToList());
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
        //public ActionResult Edit(int? id)
        //{

        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Editor editor = db.Editor.Find(id);
        //        if (editor == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        return View(editor);
        //    }
        //}
        //public ActionResult Delete(int? id)
        //{

        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Editor editor = db.Editor.Find(id);
        //        if (editor == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        return View(editor);
        //    }
        //}

        public ActionResult t1()
        {
            return View(db.Editor.Where(x => x.ed_isActive == null).ToList());

        }

        public ActionResult CreateRedaktor()
        {
            ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name");
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
        public ActionResult CreateRedaktor([Bind(Include = "ed_id,ed_name,ed_surname,ed_phone,ed_def_lng,ed_password,ed_mod,ed_isActive")] Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Editor.Add(editor);
                db.SaveChanges();
                return RedirectToAction("Requests");
            }

            ViewBag.ed_mod = new SelectList(db.Moderator, "mod_id", "mod_name", editor.ed_mod);
            return View(editor);
        }


        //GET: Editors/Edit/5
        public ActionResult EditRedaktor(int? id)
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
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRedaktor([Bind(Include = "ed_id,ed_name,ed_surname,ed_phone,ed_def_lng,ed_password,ed_mod,ed_isActive")] Editor editor)
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
        public ActionResult DeleteRedaktor(int? id)
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
        [HttpPost, ActionName("DeleteRedaktor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editor editor = db.Editor.Find(id);
            db.Editor.Remove(editor);
            db.SaveChanges();
            return RedirectToAction("Requests");
        }
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
    }


        
    
}