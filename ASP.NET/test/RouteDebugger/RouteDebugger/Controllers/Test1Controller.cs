// https://blogs.msdn.microsoft.com/webdev/2013/04/04/debugging-asp-net-web-api-with-route-debugger/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace RouteDebugger.Controllers
{
    public class Test1Controller : ApiController
    {
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.UTF8);
            return response;
        }

        public void Post()
        {

        }
    }
}
