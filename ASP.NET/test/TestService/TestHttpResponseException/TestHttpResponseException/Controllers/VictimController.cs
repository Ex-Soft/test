using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestHttpResponseException.Controllers
{
    [RoutePrefix("api/victim")]
    public class VictimController : ApiController
    {
        [Route("victim1")]
        [HttpGet]
        public object Victim1()
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
