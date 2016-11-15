using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikMvcApp.Models;

namespace TelerikMvcApp.Controllers
{
    public class StaffsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetStaffs().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, Staff staff)
        {
            if (staff != null && ModelState.IsValid)
            {
                var db = new TestDbContext();

                db.Staffs.Add(staff);
                db.SaveChanges();
            }

            return Json(new[] { staff }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Staff newValue)
        {
            Staff oldValue = null;

            if (newValue != null && ModelState.IsValid)
            {
                var db = new TestDbContext();

                if((oldValue = db.Staffs.FirstOrDefault(staff => staff.ID == newValue.ID)) != null)
                {
                    if (oldValue.Name != newValue.Name)
                    {
                        oldValue.Name = newValue.Name;
                        db.SaveChanges();
                    }
                }
            }

            return Json(new[] { oldValue ?? newValue }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, Staff staff)
        {
            Staff candidate = null;

            if (staff != null)
            {
                var db = new TestDbContext();

                if ((candidate = db.Staffs.FirstOrDefault(s => s.ID == staff.ID)) != null)
                {
                    db.Staffs.Remove(candidate);
                    db.SaveChanges();
                }
            }

            return Json(new[] { candidate ?? staff }.ToDataSourceResult(request, ModelState));
        }

        private static IEnumerable<Staff> GetStaffs()
        {
            var db = new TestDbContext();

            return db.Staffs.Select(staff => new 
            {
                staff.ID,
                staff.Name
            }).AsEnumerable().Select(x => new Staff
            {
                ID = x.ID,
                Name = x.Name
            });
            

            /*
            return (from staff in db.Staffs select
                    new Staff
                    {
                        ID = staff.ID,
                        Name = staff.Name,
                        Salary = staff.Salary,
                        Dep = staff.Dep,
                        BirthDate = staff.BirthDate
                    });
            */
        }
    }
}