using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ClassLibrary2
{
    public class ClassWithHttpClient : IClassWithHttpClient
    {
        protected HttpClient? _client = null;
        protected Uri? _uri = null;

        public ClassWithHttpClient(string uri)
        {
            _client = new HttpClient();
            _uri = new Uri(uri);
        }

        public async Task FooAsync()
        {
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(new {Id = 1}), Encoding.UTF8, "application/json");
                _ = await _client.PutAsync(_uri, content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
