using System.Web.Mvc;
using WebApp.Domain;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		ISmthEntity _smtpEntity;

		public HomeController(ISmthEntity smtpEntity)
		{
			_smtpEntity = smtpEntity;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}