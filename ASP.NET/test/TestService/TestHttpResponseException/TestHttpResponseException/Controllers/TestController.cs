using System;
using System.IO;
using System.Net;
using System.Web.Http;

namespace TestHttpResponseException.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("route1")]
        [HttpGet]
        public object Route1()
        {
            object result = null;
            WebClient client = new WebClient();

            var data = client.OpenRead("http://localhost:44331/api/victim/victim1");
            var reader = new StreamReader(data);
            result = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return result;
        }

        [Route("route2")]
        [HttpGet]
        public object Route2()
        {
            object result = null;
            WebClient client = new WebClient();

            try
            {
                var data = client.OpenRead("http://localhost:44331/api/victim/victim1");
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
                data.Close();
                reader.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return result;
        }
    }
}
