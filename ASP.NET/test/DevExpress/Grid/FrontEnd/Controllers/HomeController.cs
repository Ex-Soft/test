using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Grid.Domain.Database;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(GetAllStaffs());
        }

        public ActionResult GridViewPart()
        {
            return PartialView("GridViewPartial", GetAllStaffs());
        }

        private static IEnumerable<Staff> GetAllStaffs()
        {
            var webApi = new BackEnd.Controllers.StaffsController();
            return webApi.GetAllStaffs().ToList();
        } 
    }
}
