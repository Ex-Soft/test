using LessonProject.Controllers;
using LessonProject.Models;
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
    public abstract class AdminController : BaseController
    {
        public Language CurrentLang
        {
            get
            {
                return CurrentUser != null ? CurrentUser.Language : null;
            }
        }

        protected override void Initialize(RequestContext requestContext)
        {
            CultureInfo ci = new CultureInfo("ru");

            Thread.CurrentThread.CurrentCulture = ci;
            base.Initialize(requestContext);
        }

    }
}
