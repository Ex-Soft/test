using System.Web.Http;

namespace TestComponent.Controllers
{
    [RoutePrefix("api/data")]
    public class DataController : ApiController
    {
        [Route("data1")]
        [HttpGet]
        public object Data1()
        {
            return new [] {
                new { id = 1, value = "1st" },
                new { id = 2, value = "2nd" },
                new { id = 3, value = "3rd" }
            };
        }

        [Route("data2")]
        [HttpGet]
        public object Data2()
        {
            return new[] {
                new { id = 1, value = "I" },
                new { id = 2, value = "II" },
                new { id = 3, value = "III" }
            };
        }
    }
}