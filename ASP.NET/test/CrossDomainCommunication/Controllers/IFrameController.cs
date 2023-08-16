using CrossDomainCommunication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrossDomainCommunication.Controllers
{
    public class IFrameController : Controller
    {
        public IActionResult Index([FromQuery] int? frameNo)
        {
            return View(new IFrameViewModel { FrameNo = frameNo});
        }
    }
}
