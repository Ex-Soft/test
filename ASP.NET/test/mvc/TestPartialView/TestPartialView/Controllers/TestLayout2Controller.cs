using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestPartialView.Controllers
{
    public class TestLayout2Controller : Controller
    {
        // GET: TestLayout2
        public ActionResult Index()
        {
            return View("Index", "_TestLayout2");
        }
    }
}