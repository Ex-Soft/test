// https://github.com/reactiveui/refit

using System;
using Refit;

using static System.Console;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = RestService.For<IWeatherForecast>("http://localhost:65208");

                var weatherForecasts = client.GetAsync().Result;

                foreach (var item in weatherForecasts)
                {
                    WriteLine($"{item.Date}");
                }
            }
            catch (Exception eException)
            {
                WriteLine($"{eException.GetType().FullName}{Environment.NewLine}Message: {eException.Message}{Environment.NewLine}{(eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? $"InnerException.Message {eException.InnerException.Message}{Environment.NewLine}" : string.Empty)}StackTrace:{Environment.NewLine}{eException.StackTrace}");
            }
        }
    }
}
