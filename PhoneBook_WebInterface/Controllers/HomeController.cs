using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook_WebInterface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Obucharium, 2016.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Сведения";

            return View();
        }
    }
}