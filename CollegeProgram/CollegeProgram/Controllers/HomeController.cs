using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeProgram.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "College Program System Administration";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "College Program System Administration";

            return View();
        }
    }
}