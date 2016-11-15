using LessonProject.Models.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Areas.Default.Controllers
{
    public class SimpleFileController : DefaultController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SimpleFileView());
        }

        [HttpPost]
        public ActionResult Index(SimpleFileView simpleFileView)
        {
            return View(simpleFileView);
        }
    }
}
