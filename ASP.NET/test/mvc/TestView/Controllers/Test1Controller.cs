using System.Reflection;
using System.Web.Mvc;
using TestView.Models;

namespace TestView.Controllers
{
    public class Test1Controller : Controller
    {
        // GET: Test1
        public ActionResult Index()
        {
            return View(new Test1Model { PString = $"{MethodBase.GetCurrentMethod().DeclaringType}" });
        }
    }
}