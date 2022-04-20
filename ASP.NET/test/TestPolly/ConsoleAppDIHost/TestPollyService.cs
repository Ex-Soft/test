using Microsoft.AspNetCore.WebUtilities;

namespace ConsoleAppDIHost
{
    public class TestPollyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestPollyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task Run()
        {
            var client = _httpClientFactory.CreateClient("HttpClient");
            var query = new Dictionary<string, string>
            {
                ["t"] = DateTimeOffset.Now.ToString("O")
            };
            var uri = QueryHelpers.AddQueryString("api/values", query);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                WriteLine(data);
            }
            else
            {
                WriteLine(response.StatusCode);
            }
        }
    }
}
