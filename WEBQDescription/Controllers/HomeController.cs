using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBQDescription.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Actor()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Location()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Things()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}