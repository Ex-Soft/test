using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace TestCookies.Controllers
{
    [RoutePrefix("api/default")]
    public class DefaultController : ApiController
    {
        public HttpResponseMessage GetSmth()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.Add("Set-Cookie", "cookie1=cookie1");

            return response;
        }
    }
}
