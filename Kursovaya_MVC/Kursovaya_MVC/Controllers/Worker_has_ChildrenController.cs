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
    public class Worker_has_ChildrenController : Controller
    {
        private KadryEntities db = new KadryEntities();

        // GET: Worker_has_Children
        public ActionResult Index()
        {
            var worker_has_Children = db.Worker_has_Children.Include(w => w.Children).Include(w => w.Worker);
            return View(worker_has_Children.ToList());
        }

        // GET: Worker_has_Children/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker_has_Children worker_has_Children = db.Worker_has_Children.Find(id);
            if (worker_has_Children == null)
            {
                return HttpNotFound();
            }
            return View(worker_has_Children);
        }

        // GET: Worker_has_Children/Create
        public ActionResult Create()
        {
            var Children = db.Children.Select(ch => new
            {
                ID_Children = ch.ID_Children,
                Name = ch.ID_Children + " - " + ch.Name
            }).ToList();
            var Worker = db.Worker.Select(wr => new
            {
                N_worker = wr.N_worker,
                Full_Name = wr.N_worker + " - " + wr.Full_Name
            }).ToList();
            ViewBag.Children_ID_Children = new SelectList(Children, "ID_Children", "Name");
            ViewBag.Worker_N_worker = new SelectList(Worker, "N_worker", "Full_Name");
            return View();
        }

        // POST: Worker_has_Children/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Rec,Children_ID_Children,Worker_N_worker")] Worker_has_Children worker_has_Children)
        {
            if (ModelState.IsValid)
            {
                db.Worker_has_Children.Add(worker_has_Children);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var Children = db.Children.Select(ch => new
            {
                ID_Children = ch.ID_Children,
                Name = ch.ID_Children + " - " + ch.Name
            }).ToList();
            var Worker = db.Worker.Select(wr => new
            {
                N_worker = wr.N_worker,
                Full_Name = wr.N_worker + " - " + wr.Full_Name
            }).ToList();
            ViewBag.Children_ID_Children = new SelectList(Children, "ID_Children", "Name", worker_has_Children.Children_ID_Children);
            ViewBag.Worker_N_worker = new SelectList(Worker, "N_worker", "Full_Name", worker_has_Children.Worker_N_worker);
            return View(worker_has_Children);
        }

        // GET: Worker_has_Children/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker_has_Children worker_has_Children = db.Worker_has_Children.Find(id);
            if (worker_has_Children == null)
            {
                return HttpNotFound();
            }
            var Children = db.Children.Select(ch => new
            {
                ID_Children = ch.ID_Children,
                Name = ch.ID_Children + " - " + ch.Name
            }).ToList();
            var Worker = db.Worker.Select(wr => new
            {
                N_worker = wr.N_worker,
                Full_Name = wr.N_worker + " - " + wr.Full_Name
            }).ToList();
            ViewBag.Children_ID_Children = new SelectList(Children, "ID_Children", "Name", worker_has_Children.Children_ID_Children);
            ViewBag.Worker_N_worker = new SelectList(Worker, "N_worker", "Full_Name", worker_has_Children.Worker_N_worker);
            return View(worker_has_Children);
        }

        // POST: Worker_has_Children/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Rec,Children_ID_Children,Worker_N_worker")] Worker_has_Children worker_has_Children)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker_has_Children).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var Children = db.Children.Select(ch => new
            {
                ID_Children = ch.ID_Children,
                Name = ch.ID_Children + " - " + ch.Name
            }).ToList();
            var Worker = db.Worker.Select(wr => new
            {
                N_worker = wr.N_worker,
                Full_Name = wr.N_worker + " - " + wr.Full_Name
            }).ToList();
            ViewBag.Children_ID_Children = new SelectList(Children, "ID_Children", "Name", worker_has_Children.Children_ID_Children);
            ViewBag.Worker_N_worker = new SelectList(Worker, "N_worker", "Full_Name", worker_has_Children.Worker_N_worker);
            return View(worker_has_Children);
        }

        // GET: Worker_has_Children/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker_has_Children worker_has_Children = db.Worker_has_Children.Find(id);
            if (worker_has_Children == null)
            {
                return HttpNotFound();
            }
            return View(worker_has_Children);
        }

        // POST: Worker_has_Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker_has_Children worker_has_Children = db.Worker_has_Children.Find(id);
            db.Worker_has_Children.Remove(worker_has_Children);
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
