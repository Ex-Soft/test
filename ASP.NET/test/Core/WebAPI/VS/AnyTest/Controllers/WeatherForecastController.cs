using AnyTest.Clients;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherClient _weatherClient;

        public WeatherForecastController(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        [HttpGet("weather/{city}")]
        public async Task<IActionResult> Forecast(string city)
        {
            var weather = await _weatherClient.GetCurrentWeatherForCity(city);
            return weather != null ? Ok(weather) : NotFound();
        }
    }
}
