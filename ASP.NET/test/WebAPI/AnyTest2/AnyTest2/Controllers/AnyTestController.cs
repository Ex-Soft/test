using System;
using System.Net.Http;
using System.Web.Http;
using AnyTest2.Models;
using Newtonsoft.Json;

namespace AnyTest2.Controllers
{
    [RoutePrefix("api/anytest")]
    public class AnyTestController : ApiController
    {
        [HttpGet]
        [Route("testarraybygetihttpactionresult")]
        public IHttpActionResult TestArrayByGetIHttpActionResult()
        {
            var baseAddress = "http://localhost:54722/api/anytest/testarraybygetihttpactionresult";
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(baseAddress).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var customerJsonString = response.Content. ReadAsStringAsync().Result;
                        var cust = JsonConvert.DeserializeObject<SmthClass[]>(customerJsonString);
                    }
                    else
                    {
                        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
                }
            }

            return Ok();
        }
    }
}
