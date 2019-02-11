using System.Diagnostics;
using System.Web.Http;

namespace TestUrlRewriting.Controllers
{
    public class StubsController : ApiController
    {
        [Route("api/stubs/route1")]
        [HttpGet]
        public object Route1()
        {
            Debug.WriteLine("api/stubs/route1");
            return new { RouteId = "api/stubs/route1" };
        }

        [Route("api/stubs/route2")]
        [HttpGet]
        public object Route2()
        {
            Debug.WriteLine("api/stubs/route2");
            return new { RouteId = "api/stubs/route2" };
        }
    }
}
