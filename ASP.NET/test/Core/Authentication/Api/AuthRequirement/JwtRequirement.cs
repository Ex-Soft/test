using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Api.AuthRequirement
{
    public class JwtRequirement : IAuthorizationRequirement { }

    public class JwtRequirementHandler : AuthorizationHandler<JwtRequirement>
    {
        private readonly HttpClient _client;
        private readonly HttpContext _httContext;

        public JwtRequirementHandler(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _client = httpClientFactory.CreateClient();
            _httContext = httpContextAccessor.HttpContext;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            JwtRequirement requirement)
        {
            if (_httContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var accessToken = authHeader.ToString().Split(' ')[1];

                var response = await _client
                    .GetAsync($"http://localhost:56218/oauth/validate?access_token={accessToken}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
