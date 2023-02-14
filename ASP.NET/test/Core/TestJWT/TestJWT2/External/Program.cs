using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

var jwkString = """{"additionalData":{},"alg":null,"crv":null,"d":null,"dp":null,"dq":null,"e":"AQAB","k":null,"keyId":null,"keyOps":[],"kid":null,"kty":"RSA","n":"yUH7mYlQLRpxjaeMlKA3r4ZgcYUy5enrlhrHxh0P5aEzab-EhpnaeSOouDN5M0KJgo9ULlxB_JORplBPvuCHo9hmHzTD6-Ag2DE1Y5C8bYYFGInfwWLhZC-z0cOY8Cyiv6co9WRkjlghVtSQnoj0K3dPqJLjieokK-G5uQm8n_r_ELq062utjL2GonmRDe423kSRRNqeisyjX8s5Rj-PNmnzhUxNnaubGJFG4_eiEOWUDyiJLSEDN4yeibtLv6OYoj5k0zRu0oJpj0ZtD0ppFVJ-GLH7jj9TRTSRJW9sJ2FfaVvFRrHXPRiIMDh2-m-wVRKv2A4Fexe2TSdekOSTeQ","oth":null,"p":null,"q":null,"qi":null,"use":null,"x":null,"x5c":[],"x5t":null,"x5tS256":null,"x5u":null,"y":null,"keySize":2048,"hasPrivateKey":false,"cryptoProviderFactory":{"cryptoProviderCache":{},"customCryptoProvider":null,"cacheSignatureProviders":true,"signatureProviderObjectPoolCacheSize":48}}""";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("jwt")
    .AddJwtBearer("jwt", o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false
        };
        
        o.Events = new JwtBearerEvents
        {
            OnMessageReceived = (ctx) =>
            {
                if (ctx.Request.Query.ContainsKey("t"))
                {
                    ctx.Token = ctx.Request.Query["t"];
                }

                return Task.CompletedTask;
            }
        };

        o.Configuration = new OpenIdConnectConfiguration
        {
            SigningKeys =
            {
                JsonWebKey.Create(jwkString)
            }
        };

        o.MapInboundClaims = false;
    });

var app = builder.Build();

app.UseAuthentication();

app.MapGet("/", (ctx) =>
{
    var user = ctx.User;
    var sub = user.FindFirst("sub");
    var value = sub?.Value;
    return Task.FromResult(value ?? "empty");
});

app.MapGet("/jwt", () =>
{
    var handler = new JsonWebTokenHandler();
    var token = handler.CreateToken(new SecurityTokenDescriptor
    {
        Issuer = "https://localhost:5000",
        Subject = new ClaimsIdentity(new []
        {
            new Claim("sub", Guid.NewGuid().ToString()),
            new Claim("name", "Anonymous")
        }),
        SigningCredentials = new SigningCredentials(JsonWebKey.Create(jwkString), SecurityAlgorithms.RsaSha256)
    });

    return token;
});

app.Run();
