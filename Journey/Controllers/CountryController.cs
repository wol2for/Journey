using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journey.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            return RedirectToAction("Index","Main");
        }

        public ActionResult Egypt()
        {
            return View("Egypt");
        }

        public ActionResult Turkey()
        {
            return RedirectToAction("Index", "Main");
        }

        public ActionResult Spain()
        {
            return RedirectToAction("Index", "Main");
        }

        [ActionName("Sri-Lanka")]
        public ActionResult SriLanka()
        {
            return RedirectToAction("Index", "Main");
        }

        public ActionResult Greece()
        {
            return RedirectToAction("Index", "Main");
        }

        public ActionResult Thailand()
        {
            return RedirectToAction("Index", "Main");
        }

        public ActionResult Maldives()
        {
            return RedirectToAction("Index", "Main");
        }

        public ActionResult Montenegro()
        {
            return RedirectToAction("Index", "Main");
        }

        public ActionResult UAE()
        {
            return RedirectToAction("Index", "Main");
        }

    }
}