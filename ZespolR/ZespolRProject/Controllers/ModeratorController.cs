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

    }
}