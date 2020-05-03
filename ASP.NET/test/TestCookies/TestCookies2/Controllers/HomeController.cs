using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestCookies2.Models;

namespace TestCookies2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Submit()
        {
            var request = HttpContext.Request;
            var cookies = request.Cookies.Keys.ToDictionary(key => key, key => request.Cookies[key]);

            var response = HttpContext.Response;
            var options = new CookieOptions { Expires = new DateTimeOffset().AddYears(1) };
            response.Cookies.Append("CookieFromServer", "CookieFromServer"/*, options*/);

            return View(new SubmitViewModel { Cookies = cookies });
        }
    }
}
