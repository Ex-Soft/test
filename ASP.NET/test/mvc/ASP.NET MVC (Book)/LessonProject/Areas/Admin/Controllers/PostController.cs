using LessonProject.Models;
using LessonProject.Models.Info;
using LessonProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Areas.Admin.Controllers
{
    public class PostController : AdminController
    {
        public ActionResult Index(int page = 1)
        {
            var list = Repository.Posts.OrderByDescending(p => p.AddedDate);
            var data = new PageableData<Post>(list, page);
            data.List.ForEach(p => p.CurrentLang = CurrentLang.ID);
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var postView = new PostView 
            {
                CurrentLang = CurrentLang.ID
            };
            return View("Edit", postView);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var post = Repository.Posts.FirstOrDefault(p => p.ID == id);
            if (post != null)
            {
                post.CurrentLang = CurrentLang.ID;
                var postView = (PostView)ModelMapper.Map(post, typeof(Post), typeof(PostView));
                return View(postView);
            }
            return RedirectToNotFoundPage;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PostView postView)
        {
            if (ModelState.IsValid)
            {
                var post = (Post)ModelMapper.Map(postView, typeof(PostView), typeof(Post));
                post.CurrentLang = CurrentLang.ID;
                if (post.ID == 0)
                {
                    post.UserID = CurrentUser.ID;
                    Repository.CreatePost(post);
                }
                else
                {
                    Repository.UpdatePost(post);
                }
                TempData["Message"] = "Сохранено!";
                return RedirectToAction("Index");
            }
            return View(postView);
        }

        public ActionResult Delete(int id)
        {
            Repository.RemovePost(id);
            TempData["Message"] = "Удален пост";

            return RedirectToAction("Index");
        }
    }
}
