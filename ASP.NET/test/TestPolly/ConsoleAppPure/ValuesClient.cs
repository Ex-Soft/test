using System.Net;
using Microsoft.AspNetCore.WebUtilities;
using Polly;
using Polly.Retry;
using static System.Console;

namespace ConsoleAppPure
{
    public class ValuesClient
    {
        private const string AttemptNumber = "attemptNumber";
        private readonly HttpClient _httpClient;
        private AsyncRetryPolicy _retryPolicy;

        public ValuesClient(IRetryDelayCalculator retryDelayCalculator)
        {
            const int maxRetries = 3;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5294");

            _retryPolicy = Policy.Handle<HttpRequestException>(ex => ex.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(
                    retryCount: maxRetries,
                    sleepDurationProvider: retryDelayCalculator.Calculate,
                    onRetry: (exception, sleepDuration, attemptNumber, context) =>
                    {
                        context[AttemptNumber] = attemptNumber;
                        Log($"Too many requests. Retrying in {sleepDuration}. {attemptNumber} / {maxRetries} ({exception.Message})");
                    });
        }
        
        private void Log(string message)
        {
            WriteLine($"{DateTime.Now:hh:mm:ss.ffff} {message}");
        }

        public async Task<string> GetValues()
        {
            var context = new Context
            {
                { AttemptNumber, 0 }
            };

            return await _retryPolicy.ExecuteAsync(async (ctx) =>
            {
                var query = new Dictionary<string, string>();

                if (ctx?[AttemptNumber] != null)
                {
                    query["n"] = ctx[AttemptNumber].ToString();
                }

                var uri = QueryHelpers.AddQueryString("api/values", query);
                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }, context);
        }
	}
}
