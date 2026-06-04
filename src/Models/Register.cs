using System.Text.Json.Serialization;

class Register
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }

    public Register (string email, string username, string password)
    {
        this.Email = email;
        this.Username = username;
        this.Password = password;
    }
}