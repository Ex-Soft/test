using System.Web.Mvc;
using TestController.Models;

namespace TestController.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public int GetInt(string fString, int fInt)
        {
            return fInt * (!string.IsNullOrWhiteSpace(fString) ? fString.Length : 0);
        }

        public ActionResult GetJson(string fString, int fInt)
        {
            return Json(new ResponseModel { fString = fString, fInt = fInt }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int PostInt(string fString, int fInt)
        {
            return fInt * (!string.IsNullOrWhiteSpace(fString) ? fString.Length : 0);
        }

        [HttpPost]
        public ActionResult PostJson(string fString, int fInt)
        {
            return Json(new ResponseModel { fString = fString, fInt = fInt });
        }

        [HttpPost]
        public int PostJsonInt(RequestModel data)
        {
            return data != null ? (data.fInt * (!string.IsNullOrWhiteSpace(data.fString) ? data.fString.Length : 0)) : 0;
        }

        [HttpPost]
        public ActionResult PostJsonJson(RequestModel data)
        {
            return Json(new ResponseModel { fString = data != null ? data.fString : null, fInt = data != null ? data.fInt : 0 });
        }
    }
}
