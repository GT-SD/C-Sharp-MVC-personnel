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
    public class Worker_has_DepartmentController : Controller
    {
        private KadryEntities db = new KadryEntities();

        // GET: Worker_has_Department
        public ActionResult Index()
        {
            var worker_has_Department = db.Worker_has_Department.Include(w => w.Department).Include(w => w.Worker);
            return View(worker_has_Department.ToList());
        }

        // GET: Worker_has_Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker_has_Department worker_has_Department = db.Worker_has_Department.Find(id);
            if (worker_has_Department == null)
            {
                return HttpNotFound();
            }
            return View(worker_has_Department);
        }

        // GET: Worker_has_Department/Create
        public ActionResult Create()
        {
            var Department = db.Department.Select(dp => new
            {
                ID_Department = dp.ID_Department,
                Name = dp.ID_Department + " - " + dp.Name
            }).ToList();
            var Worker = db.Worker.Select(wr => new
            {
                N_worker = wr.N_worker,
                Full_Name = wr.N_worker + " - " + wr.Full_Name
            }).ToList();
            ViewBag.Department_ID_Department = new SelectList(Department, "ID_Department", "Name");
            ViewBag.Worker_N_worker = new SelectList(Worker, "N_worker", "Full_Name");
            return View();
        }

        // POST: Worker_has_Department/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Appointment,Worker_N_worker,Department_ID_Department,Date_Start,Date_End")] Worker_has_Department worker_has_Department)
        {
            if (ModelState.IsValid)
            {
                db.Worker_has_Department.Add(worker_has_Department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var Department = db.Department.Select(dp => new
            {
                ID_Department = dp.ID_Department,
                Name = dp.ID_Department + " - " + dp.Name
            }).ToList();
            var Worker = db.Worker.Select(wr => new
            {
                N_worker = wr.N_worker,
                Full_Name = wr.N_worker + " - " + wr.Full_Name
            }).ToList();
            ViewBag.Department_ID_Department = new SelectList(Department, "ID_Department", "Name", worker_has_Department.Department_ID_Department);
            ViewBag.Worker_N_worker = new SelectList(Worker, "N_worker", "Full_Name", worker_has_Department.Worker_N_worker);
            return View(worker_has_Department);
        }

        // GET: Worker_has_Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker_has_Department worker_has_Department = db.Worker_has_Department.Find(id);
            if (worker_has_Department == null)
            {
                return HttpNotFound();
            }
            var Department = db.Department.Select(dp => new
            {
                ID_Department = dp.ID_Department,
                Name = dp.ID_Department + " - " + dp.Name
            }).ToList();
            var Worker = db.Worker.Select(wr => new
            {
                N_worker = wr.N_worker,
                Full_Name = wr.N_worker + " - " + wr.Full_Name
            }).ToList();
            ViewBag.Department_ID_Department = new SelectList(Department, "ID_Department", "Name", worker_has_Department.Department_ID_Department);
            ViewBag.Worker_N_worker = new SelectList(Worker, "N_worker", "Full_Name", worker_has_Department.Worker_N_worker);
            return View(worker_has_Department);
        }

        // POST: Worker_has_Department/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Appointment,Worker_N_worker,Department_ID_Department,Date_Start,Date_End")] Worker_has_Department worker_has_Department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker_has_Department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var Department = db.Department.Select(dp => new
            {
                ID_Department = dp.ID_Department,
                Name = dp.ID_Department + " - " + dp.Name
            }).ToList();
            var Worker = db.Worker.Select(wr => new
            {
                N_worker = wr.N_worker,
                Full_Name = wr.N_worker + " - " + wr.Full_Name
            }).ToList();
            ViewBag.Department_ID_Department = new SelectList(Department, "ID_Department", "Name", worker_has_Department.Department_ID_Department);
            ViewBag.Worker_N_worker = new SelectList(Worker, "N_worker", "Full_Name", worker_has_Department.Worker_N_worker);
            return View(worker_has_Department);
        }

        // GET: Worker_has_Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker_has_Department worker_has_Department = db.Worker_has_Department.Find(id);
            if (worker_has_Department == null)
            {
                return HttpNotFound();
            }
            return View(worker_has_Department);
        }

        // POST: Worker_has_Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker_has_Department worker_has_Department = db.Worker_has_Department.Find(id);
            db.Worker_has_Department.Remove(worker_has_Department);
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
