using System.Web.Mvc;
using TestPivotReportWithPaging.Models;

namespace TestPivotReportWithPaging.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataBindingToLargeDatabasePartial()
        {
            return PartialView("PivotGridPartialView", new TestPivotReportDbContext());
        }
    }
}

/* .BindToEF(string.Empty, string.Empty, (s, e) => { e.KeyExpression = "id"; e.QueryableSource = Model.Data4TestDEPivotGrids; }).GetHtml() */
/* .BindToLINQ(string.Empty, String.Empty, (s, e) => { e.QueryableSource = Model.Data4TestDEPivotGrids; }).GetHtml() */