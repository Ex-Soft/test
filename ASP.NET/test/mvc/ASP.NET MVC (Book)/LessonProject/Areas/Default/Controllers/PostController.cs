using LessonProject.Models;
using LessonProject.Models.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Areas.Default.Controllers
{
    public class PostController : DefaultController
    {
        public ActionResult Index(int page = 1)
        {
            var list = Repository.Posts.OrderByDescending(p => p.AddedDate);
            var data = new PageableData<Post>(list, page);
            data.List.ForEach(p => p.CurrentLang = CurrentLang.ID);
            return View(data);
        }
    }
}
