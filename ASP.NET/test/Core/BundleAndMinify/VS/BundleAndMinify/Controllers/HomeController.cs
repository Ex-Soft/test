using Microsoft.AspNetCore.Mvc;

namespace BundleAndMinify.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
