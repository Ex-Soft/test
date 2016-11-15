using System;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/helloworld")]
    public class HelloWorldController : Controller
    {
        [HttpGet]
        public object Get()
        {
            return new
            {
                message = "Hello World",
                time = DateTime.Now
            };
        }
    }
}
