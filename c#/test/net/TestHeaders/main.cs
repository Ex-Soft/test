using static System.Console;

HttpRequestMessage httpRequestMessage = new();
httpRequestMessage.Headers.Add("FiRsT", "1st");
httpRequestMessage.Headers.Add("sEcOnD", "2nd");
httpRequestMessage.Headers.Add("ThIrD", "3rd");

var key = "fIrSt";
IEnumerable<string> values;
bool result;
if (httpRequestMessage.Headers.Contains(key))
{
    values = httpRequestMessage.Headers.GetValues(key);
    WriteLine($"[\"{key}\"] = \"{values}\"");
}

key = "SeCoNd";
result = httpRequestMessage.Headers.TryAddWithoutValidation(key, "2nd2nd");
if (result && httpRequestMessage.Headers.Contains(key))
{
    values = httpRequestMessage.Headers.GetValues(key);
    WriteLine($"[\"{key}\"] = \"{values}\"");
}
