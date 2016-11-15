using LessonProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Models.ViewModels
{
    public class LangAdminView
    {
        private IRepository Repository
        {
            get
            {
                return DependencyResolver.Current.GetService<IRepository>();
            }
        }

        public string SelectedLang {get; set; }

        public List<SelectListItem> Langs { get; set; }

        public LangAdminView(string currentLang)
        {
            currentLang = currentLang ?? "";
            Langs = new List<SelectListItem>();

            foreach (var lang in Repository.Languages)
            {
                Langs.Add(new SelectListItem()
                {
                    Selected = (string.Compare(currentLang, lang.Code, true) == 0),
                    Value = lang.Code,
                    Text = lang.Name
                });
            }
        }
    }
}