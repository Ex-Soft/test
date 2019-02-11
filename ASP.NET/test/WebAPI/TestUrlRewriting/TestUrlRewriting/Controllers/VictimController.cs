using System.Diagnostics;
using System.Web.Http;

namespace TestUrlRewriting.Controllers
{
    [RoutePrefix("api/victim")]
    public class VictimController : ApiController
    {
        [Route("route1")]
        [HttpGet]
        public object Route1()
        {
            Debug.WriteLine("api/victim/route1");
            return new { RouteId = "api/victim/route1" };
        }

        [Route("route2")]
        [HttpGet]
        public object Route2()
        {
            Debug.WriteLine("api/victim/route2");
            return new { RouteId = "api/victim/route2" };
        }
    }
}
