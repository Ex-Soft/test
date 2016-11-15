using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["greeting"] = string.Format("Good {0}", DateTime.Now.Hour < 12 ? "morning" : "afternoon");
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ViewResult RSVPForm()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ViewResult RSVPForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                guestResponse.Submit();
                return View("Thanks", guestResponse);
            }
            else
                return View();
        }
    }
}
