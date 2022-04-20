using System.Net;

using static System.Console;

HttpResponseMessage response;
using (var client = new HttpClient())
{
    response = client.GetAsync("http://localhost:5294/api/values").Result;
}

if (response.StatusCode == HttpStatusCode.OK)
{
    var data = response.Content.ReadAsStringAsync().Result;
    WriteLine(data);
}