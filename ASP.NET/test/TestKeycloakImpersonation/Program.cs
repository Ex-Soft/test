// #define LOCAL

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

using TestKeycloakImpersonation;

// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0#cors
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

#if LOCAL
    const string realm = "myrealm";
    const string authServerUrl = "http://localhost:8080/auth/"; // "http://localhost:8080/auth/"
    const string testUserId = "56c18e13-bff8-41dd-97b6-185fb4650b76";
    const string requestedSubject = "testuser";
#else
    const string realm = "the-marketing-zone-dev";
    const string authServerUrl = "https://auth-dev.thedirectvmarketingzone.com/auth/";
    const string testUserId = "c97fb064-b0e7-4913-9889-88df6304bdec";
    const string requestedSubject = "testuser@mailinator.com";
#endif

const string clientId = "react-auth";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "http://localhost:4200");
        });
});

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

app.MapGet("/impersonateByTokenExchange", async () => await ImpersonateByTokenExchange());
app.MapGet("/impersonateByImpersonation", /*[EnableCors(MyAllowSpecificOrigins)]*/ async () => await ImpersonateByImpersonation())/*.RequireCors(MyAllowSpecificOrigins)*/;

async Task<IResult> ImpersonateByTokenExchange()
{
    TokenResponse? impersonatorTokens = JsonSerializer.Deserialize<TokenResponse>(await Token(new Dictionary<string, string>
    {
        {"client_id", clientId},
        {"grant_type", "password"},
        {"username", "myuser@mailinator.com"},
        {"password", "myuser"}
    }));

    TokenResponse? impersonatedTokens = JsonSerializer.Deserialize<TokenResponse>(await Token(new Dictionary<string, string>
    {
        { "client_id", clientId },
        { "grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" },
        { "requested_subject", requestedSubject },
        { "subject_token", impersonatorTokens.AccessToken },
        { "requested_token_type", "urn:ietf:params:oauth:token-type:refresh_token" },
        { "audience", clientId }
    }, impersonatorTokens.AccessToken));
    
    return Results.Json(impersonatedTokens);
}

async Task<string> Token(Dictionary<string, string> data, string? token = null)
{
    string? result;

    try
    {
        using HttpClient httpClient = new HttpClient();
        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{authServerUrl}realms/{realm}/protocol/openid-connect/token"));
        using FormUrlEncodedContent content = new FormUrlEncodedContent(data);
        request.Content = content;

        if (token != null)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        
        using HttpResponseMessage response = await httpClient.SendAsync(request);
        //response.EnsureSuccessStatusCode();
        result = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        throw;
    }

    return result;
}

async Task<IResult> ImpersonateByImpersonation()
{
    TokenResponse? impersonatorTokens = JsonSerializer.Deserialize<TokenResponse>(await Token(new Dictionary<string, string>
    {
        {"client_id", clientId},
        {"grant_type", "password"},
        {"username", "myuser@mailinator.com"},
        {"password", "myuser"}
    }));

    (string, IEnumerable<string>)? impersonateData = await Impersonate($"{{\"realm\":\"{realm}\",\"user\":\"{testUserId}\"}}", testUserId, impersonatorTokens.AccessToken);

    Regex re = new Regex("expires=.+?1970.+?;", RegexOptions.IgnoreCase);
    string[] cookies = impersonateData.Value.Item2.Where(item => !re.IsMatch(item)).ToArray();
    string? redirectUri = (await Auth(String.Join("; ", cookies)))?.ToString();

    re = new Regex("(?<=session_state=).+?(?=&)");
    Match match = re.Match(redirectUri);
    string sessionState = match.Value;
    
    re = new Regex("(?<=access_token=).+?(?=&)");
    match = re.Match(redirectUri);
    string accessToken = match.Value;
    
    re = new Regex("(?<=token_type=).+?(?=&)");
    match = re.Match(redirectUri);
    string tokenType = match.Value;
    
    string? redirectUriCode = (await Auth(String.Join("; ", cookies), "code"))?.ToString();
    
    re = new Regex("(?<=session_state=).+?(?=&)");
    match = re.Match(redirectUriCode);
    string sessionStateCode = match.Value;
    
    re = new Regex("(?<=code=).+?(?=$)");
    match = re.Match(redirectUriCode);
    string code = match.Value;
    
    /*TokenResponse? tokens = JsonSerializer.Deserialize<TokenResponse>(await Token(new Dictionary<string, string>
    {
        {"client_id", clientId},
        {"grant_type", "authorization_code"},
        {"code", code},
        {"redirect_uri", "http://localhost:3000/" /* "http%3A%2F%2Flocalhost%3A3000%2F" #1#}
    }, accessToken));*/
    
    return Results.Json(new { sessionState, tokenType, accessToken, redirectUri, sessionStateCode, code, redirectUriCode, cookies });
}

async Task<(string, IEnumerable<string>)?> Impersonate(string data, string userId, string token)
{
    (string, IEnumerable<string>)? result;

    try
    {
        using HttpClient httpClient = new HttpClient();
        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{authServerUrl}admin/realms/{realm}/users/{userId}/impersonation"));
        using StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        request.Content = content;
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        using HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        result = (await response.Content.ReadAsStringAsync(), response.Headers.GetValues("set-cookie"));
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        throw;
    }

    return result;
}

async Task<Uri?> Auth(string? cookies = null, string? responseType = "token")
{
    Uri? result;

    try
    {
        var httpClientHandler = new HttpClientHandler()
        {
            AllowAutoRedirect = false
            //MaxAutomaticRedirections = 1
        };
        
        using HttpClient httpClient = new HttpClient(httpClientHandler);
        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"{authServerUrl}realms/{realm}/protocol/openid-connect/auth?response_mode=fragment&response_type={responseType}&client_id={clientId}&redirect_uri=http%3A%2F%2Flocalhost%3A3000"));
        if (cookies != null)
            request.Headers.Add("Cookie", cookies);
        using HttpResponseMessage response = await httpClient.SendAsync(request);
        
        result = response.Headers.Location;
        //result = request.RequestUri;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        throw;
    }

    return result;
}

app.Run();
