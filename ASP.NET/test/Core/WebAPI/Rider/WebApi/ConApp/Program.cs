try
{
    using var client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:5063");
    client.DefaultRequestHeaders.Accept.Clear();
    var response = await client.GetAsync("/weatherforecast");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
