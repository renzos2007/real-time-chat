using System.Text.Json.Serialization;

class Login
{
    [JsonPropertyName("emailOrUsername")]
    public string EmailOrUsername { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }

    public Login(string emailOrUsername, string password)
    {
        EmailOrUsername = emailOrUsername;
        Password = password;
    }
}