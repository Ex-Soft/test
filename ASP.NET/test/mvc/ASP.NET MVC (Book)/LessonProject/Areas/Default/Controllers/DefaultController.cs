using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LessonProject.Controllers;
using System.Globalization;
using System.Threading;
using LessonProject.Models;

namespace LessonProject.Areas.Default.Controllers
{
    public class DefaultController : BaseController
    {
        public string CurrentLangCode { get; protected set; }

        public Language CurrentLang { get; protected set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }

            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                CurrentLangCode = requestContext.RouteData.Values["lang"] as string;
                CurrentLang = Repository.Languages.FirstOrDefault(p => p.Code == CurrentLangCode);

                var ci = new CultureInfo(CurrentLangCode);
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
            base.Initialize(requestContext);
        }
    }
}
