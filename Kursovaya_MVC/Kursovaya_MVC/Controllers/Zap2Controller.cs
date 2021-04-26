using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kursovaya_MVC.Controllers
{
    public class Zap2Controller : Controller
    {
        private KadryEntities db = new KadryEntities();
        // GET: Zap2
        public ActionResult Index()
        {
            var zap2 = db.Work_chi();
            return View(zap2);
        }
    }
}