using System.Text.Json.Serialization;

namespace TestKeycloakImpersonation;

public class ImpersonationResponse
{
    [JsonPropertyName("redirect")]
    public string? Redirect { get; set; }
    
    [JsonPropertyName("sameRealm")]
    public bool? SameRealm { get; set; }
}