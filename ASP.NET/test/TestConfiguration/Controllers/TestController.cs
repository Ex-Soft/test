using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TestConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private TestType _testType;

        public TestController(IOptions<TestType> testType)
        {
            _testType = testType?.Value;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"{(_testType != null ? $"{{PString=\"{_testType.PString}\", PType=\"{_testType.PType}\"}}" : "null")}";
        }
    }
}
