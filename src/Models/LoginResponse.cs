using System.Text.Json.Serialization;

class LoginResponse
{
    [JsonPropertyName("username")]
    public required string username { get; set; }
}