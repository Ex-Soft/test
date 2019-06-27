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
    }
}
