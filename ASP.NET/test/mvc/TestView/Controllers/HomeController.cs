using System.Web.Mvc;
using TestView.Models;

namespace TestView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ViewResponse viewResponse)
        {
            return View(viewResponse);
        }
    }
}
