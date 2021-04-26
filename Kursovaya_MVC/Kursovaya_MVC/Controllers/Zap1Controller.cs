using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kursovaya_MVC.Controllers
{
    public class Zap1Controller : Controller
    {
        private KadryEntities db = new KadryEntities();
        // GET: Zap1
        public ActionResult Index()
        {
            SelectList dep = new SelectList(db.Department, "Name", "Name");
            ViewBag.dep = dep;
            RedirectToAction("Worker");
            return View();
        }


        // [HttpPost]
        public ActionResult Worker(string otdel, DateTime dat)
        {
            var zap1 = db.Work_wrk(otdel, dat).ToList();
            return View(zap1);
        }
    }
}