using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LessonProject.Models;
using Ninject;
using LessonProject.Attribute;

namespace LessonProject.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

        [AllowCrossSiteJson]
        public ActionResult OK()
        {
            return Json(new { result = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}
