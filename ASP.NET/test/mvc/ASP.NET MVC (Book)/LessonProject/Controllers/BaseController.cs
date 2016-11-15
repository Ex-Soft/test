using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using LessonProject.App_Start;
using LessonProject.Global.Auth;
using LessonProject.Global.Config;
using LessonProject.Mappers;
using LessonProject.Models;
using Ninject;

namespace LessonProject.Controllers
{
    public abstract class BaseController : Controller
    {
        public static string HostName = string.Empty;


        [Inject]
        public IRepository Repository { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }

        [Inject]
        public IConfig Config { get; set; }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

        protected static string ErrorPage = "~/Error";

        protected static string NotFoundPage = "~/NotFoundPage";

        protected static string LoginPage = "~/Login";

        public RedirectResult RedirectToNotFoundPage
        {
            get
            {
                return Redirect(NotFoundPage);
            }
        }

        public RedirectResult RedirectToLoginPage
        {
            get
            {
                return Redirect(LoginPage);
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }
            base.Initialize(requestContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            filterContext.Result = Redirect(ErrorPage);
        }
    }
}
