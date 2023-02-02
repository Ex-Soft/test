using Microsoft.AspNetCore.Mvc;
using AnyTest.Models;

namespace AnyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnyTestController : ControllerBase
    {
        [HttpGet]
        [Route("getsmthenum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public GetSmthEnumResponse GetSmthEnum()
        {
            return new GetSmthEnumResponse { SmthEnum = Enum.GetValues(typeof(SmthEnum)) as SmthEnum[] };
        }

        [HttpGet]
        [Route("getsmthenumstr")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public GetSmthEnumStrResponse GetSmthEnumStr()
        {
            return new GetSmthEnumStrResponse { SmthEnumStr = Enum.GetNames(typeof(SmthEnum)) };
        }

        [HttpGet]
        [Route("testarraybyget")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public GetSmthEnumStrResponse TestArrayByGet([FromQuery]TestArrayByGetRequest request)
        {
            return new GetSmthEnumStrResponse { SmthEnumStr = request.Values.Select(item => item.ToString()).ToArray() };
        }

        [HttpGet]
        [Route("testarraybygetiactionresult")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult TestArrayByGetIActionResult([FromQuery] TestArrayByGetRequest request)
        {
            return Ok(new SmthClass[] {
                new SmthClass { PString = "PString# 1", PArrayOfString = new string[] { "PString# 1.1", "PString# 1.2", "PString# 1.3" } },
                new SmthClass { PString = "PString# 2", PArrayOfString = new string[] { "PString# 2.1", "PString# 2.2", "PString# 2.3" } },
                new SmthClass { PString = "PString# 3", PArrayOfString = new string[] { "PString# 3.1", "PString# 3.2", "PString# 3.3" } }
            });
        }
    }
}
