using System.Reflection;
using System.Web.Mvc;
using TestView.Models;

namespace TestView.Controllers
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            return View(new Test2Model { PString = $"{MethodBase.GetCurrentMethod().DeclaringType}" });
        }
    }
}