using System.Web.Mvc;

namespace TestSubmit.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

    }

    public class ModelTestView
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
    }
}
