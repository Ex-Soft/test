using CrossDomainCommunication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrossDomainCommunication.Controllers
{
    public class IFrameController : Controller
    {
        public IActionResult Index([FromQuery] int? frameNo)
        {
            // doesn't work (Access-Control-Allow-Origin is used only for XHR)
            // Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return View(new IFrameViewModel { FrameNo = frameNo});
        }
    }
}
