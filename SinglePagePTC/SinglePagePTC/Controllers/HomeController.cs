using SinglePage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePagePTC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            return View(mgr.Get());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}