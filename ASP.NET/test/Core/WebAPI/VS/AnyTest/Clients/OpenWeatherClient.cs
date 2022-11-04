using AnyTest.Models;

namespace AnyTest.Clients
{
    public interface IWeatherClient
    {
        Task<WeatherResponse?> GetCurrentWeatherForCity(string city);
    }

    public class OpenWeatherClient : IWeatherClient
    {
        private const string OpenWeatherApiKey = "7975a7da373c109cb621fe8e7fa74400";

        #if USE_HTTP_CLIENT_FACTORY
            private readonly IHttpClientFactory _httpClientFactory;
        #else
            private readonly HttpClient _httpClient;
        #endif
        
        #if USE_HTTP_CLIENT_FACTORY
            public OpenWeatherClient(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }
        #else
            public OpenWeatherClient(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }
        #endif

        public async Task<WeatherResponse?> GetCurrentWeatherForCity(string city)
        {
            #if USE_HTTP_CLIENT_FACTORY
                var _httpClient = _httpClientFactory.CreateClient("weatherapi");
            #endif

            return await _httpClient.GetFromJsonAsync<WeatherResponse>($"weather?q={city}&appid={OpenWeatherApiKey}&units=metric");
        }
    }
}
