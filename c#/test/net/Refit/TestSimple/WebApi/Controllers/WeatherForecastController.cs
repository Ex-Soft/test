using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        [FromHeader]
        public string Code { get; set; }

        [FromHeader]
        public string Env { get; set; }

        [FromHeader(Name = "X-Extra")]
        public string Extra { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        [HttpGet("/group/{id}/users")]
        public IActionResult GroupList(int id, [FromQuery] string sort)
        {
            return Ok($"{{id: {id}{(!string.IsNullOrWhiteSpace(sort) ? $", sort: \"{sort}\"" : string.Empty)}{(!string.IsNullOrWhiteSpace(Code) ? $", Code: \"{Code}\"" : string.Empty)}{(!string.IsNullOrWhiteSpace(Env) ? $", Env: \"{Env}\"" : string.Empty)}{(!string.IsNullOrWhiteSpace(Extra) ? $", Extra: \"{Extra}\"" : string.Empty)}}}");
        }

        [HttpGet("/group/{id}/users/{userId}")]
        public IActionResult GroupList(int id, int userId)
        {
            return Ok($"{{id: {id}, userId: {userId}}}");
        }
    }
}
