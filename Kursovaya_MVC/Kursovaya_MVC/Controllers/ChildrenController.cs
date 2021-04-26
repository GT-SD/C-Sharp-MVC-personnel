using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kursovaya_MVC;

namespace Kursovaya_MVC.Controllers
{
    public class ChildrenController : Controller
    {
        private KadryEntities db = new KadryEntities();

        // GET: Children
        public ActionResult Index()
        {
            return View(db.Children.ToList());
        }

        // GET: Children/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // GET: Children/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Children/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Children,Name,Sex,Birthday")] Children children)
        {
            if (ModelState.IsValid)
            {
                db.Children.Add(children);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(children);
        }

        // GET: Children/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // POST: Children/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Children,Name,Sex,Birthday")] Children children)
        {
            if (ModelState.IsValid)
            {
                db.Entry(children).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(children);
        }

        // GET: Children/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Children children = db.Children.Find(id);
            db.Children.Remove(children);
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
