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

                var resultStr = client.GroupList(13).Result;
                WriteLine(resultStr);

                resultStr = client.GroupList(new UserGroupRequest {groupId = 13, userId = 26}).Result;
                WriteLine(resultStr);

                resultStr = client.GroupList(13, "desc").Result;
                WriteLine(resultStr);

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
