using System;
using System.Linq;
using System.Web.Http;
using AnyTest.Models;

namespace AnyTest.Controllers
{
    [RoutePrefix("api/anytest")]
    public class AnyTestController : ApiController
    {
        [HttpGet]
        [Route("getsmthenum")]
        public GetSmthEnumResponse GetSmthEnum()
        {
            return new GetSmthEnumResponse { SmthEnum = Enum.GetValues(typeof(SmthEnum)) as SmthEnum[] };
        }

        [HttpGet]
        [Route("getsmthenumstr")]
        public GetSmthEnumStrResponse GetSmthEnumStr()
        {
            return new GetSmthEnumStrResponse { SmthEnumStr = Enum.GetNames(typeof(SmthEnum)) };
        }

        [HttpGet]
        [Route("testarraybyget")]
        public GetSmthEnumStrResponse TestArrayByGet([FromUri]TestArrayByGetRequest request)
        {
            return new GetSmthEnumStrResponse { SmthEnumStr = request.Values.Select(item => item.ToString()).ToArray() };
        }

        [HttpGet]
        [Route("testarraybygetihttpactionresult")]
        public IHttpActionResult TestArrayByGetIHttpActionResult([FromUri] TestArrayByGetRequest request)
        {
            return Ok(new SmthClass[] {
                new SmthClass { PString = "PString# 1", PArrayOfString = new string[] { "PString# 1.1", "PString# 1.2", "PString# 1.3" } },
                new SmthClass { PString = "PString# 2", PArrayOfString = new string[] { "PString# 2.1", "PString# 2.2", "PString# 2.3" } },
                new SmthClass { PString = "PString# 3", PArrayOfString = new string[] { "PString# 3.1", "PString# 3.2", "PString# 3.3" } }
            });
        }
    }
}
