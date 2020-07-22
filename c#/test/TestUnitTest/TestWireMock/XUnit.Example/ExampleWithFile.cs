using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Text;
using WireMock.Server;
using WireMock.Settings;
using Xunit;

namespace XUnit.Example
{
    public class ExampleWithFile : IDisposable
    {
        private readonly WireMockServer stub;
        private readonly string baseUrl;

        public ExampleWithFile()
        {
            var port = new Random().Next(5000, 6000);
            baseUrl = "http://localhost:" + port;
            
            stub = WireMockServer.Start(new FluentMockServerSettings
            {
                Urls = new[] { "http://+:" + port },
                ReadStaticMappings = true
            });
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                stub.Stop();
                stub.Dispose();
            }
        }


        [Fact]
        public void Test()
        {
            var bodyContent = new[] {
                                new {id = 1, description = "Book A" },
                                new {id = 2, description = "Book B" }
                            };

            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/products");

            var response = client.Execute(request);
            Assert.Equal(200, (int)response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(bodyContent), response.Content);
        }

        [Fact]
        public void TestStaticMapping()
        {
            var bodyContent = new {body = "static mapping"};

            var client = new RestClient(baseUrl);
            var request = new RestRequest("/static/mapping");

            var response = client.Execute(request);
            var customHeader = response.Headers.FirstOrDefault(item => item.Name == "Test-X");
            Assert.Equal(200, (int)response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(bodyContent), response.Content);
            Assert.NotNull(customHeader);
            Assert.Equal("test 1, test 2", customHeader.Value);
        }

        [Fact]
        public void TestPost()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/proxy-google-test-post");

            var response = client.Execute(request, Method.POST);
            var bodyContent = Encoding.UTF8.GetString(response.RawBytes);
            Assert.Equal(404, (int)response.StatusCode);
            Assert.Equal(response.Content, bodyContent);
        }
    }
}
