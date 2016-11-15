using LessonProject.Models;
using LessonProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LessonProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin,customer")]
    public class HomeController : AdminController
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminMenu()
        {
            return View();
        }

        public ActionResult LangMenu()
        {
            if (CurrentLang == null)
            {
                var lang = Repository.Languages.FirstOrDefault();
                if (lang == null)
                {
                    throw new ArgumentNullException("Введите языки в базу");
                }
                Repository.ChangeLanguage(CurrentUser, lang.Code);
            }
            var langProxy = new LangAdminView(CurrentLang.Code);
            return View(langProxy);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(string SelectedLang)
        {
            Repository.ChangeLanguage(CurrentUser, SelectedLang);
            return Redirect("~/admin");
        }
    }
}