using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Client
{
    public interface IWeatherForecast
    {
        [Get("/weatherforecast")]
        Task<IEnumerable<WeatherForecast>> GetAsync();
    }
}
