using AnyTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    public class RazorController : Controller
    {
        public IActionResult Index(bool createOuterDiv, bool createInnerDiv)
        {
            return View(new RazorViewModel { CreateOuterDiv = createOuterDiv, CreateInnerDiv = createInnerDiv, OuterDivCssClass = "outer-div", InnerDivCssClass = "inner-div", Content = "Content" });
        }
    }
}
