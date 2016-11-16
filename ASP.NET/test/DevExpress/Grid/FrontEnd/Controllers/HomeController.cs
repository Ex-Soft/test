using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var webApi = new BackEnd.Controllers.StaffsController();
            return View(webApi.GetAllStaffs());
        }
    }
}