using AnyTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PopulatePartialView1() => PartialView("_HomePartialView1");
        public IActionResult PopulatePartialView2() => PartialView("_HomePartialView2");
        public IActionResult PopulatePartialViewWithModel1() => PartialView("_HomePartialView1", new PartialViewModel { PString1 = "PopulatePartialViewWithModel1().PString1Value", PString2 = "PopulatePartialViewWithModel1().PString2Value" });
        public IActionResult PopulatePartialViewWithModel2() => PartialView("_HomePartialView2", new PartialViewModel { PString1 = "PopulatePartialViewWithModel2().PString1Value", PString2 = "PopulatePartialViewWithModel2().PString2Value" });
    }
}
