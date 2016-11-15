using LessonProject.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Areas.Default.Controllers
{
    public class FeedController : DefaultController
    {
        public ActionResult Index()
        {
            var host = Request.Url;
            var feed =
               new SyndicationFeed("Site RSS",
                                   "",
                                   new Uri("http://" + host.Authority + "/Feed"));

            var items = new List<SyndicationItem>();

            var item = new SyndicationItem(
               "Title",
               "content",
               new Uri("http://" + host.Authority + "/some-link-url"),
               "Title",
               DateTime.Now
               );
            items.Add(item);
            feed.Items = items;

            return new RssActionResult {Feed = feed };
        }

    }
}
