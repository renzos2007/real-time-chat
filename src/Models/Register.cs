class Register
{
    private string Email;
    private string Username;
    private string Password;

    public Register (string email, string username, string password)
    {
        this.Email = email;
        this.Username = username;
        this.Password = password;
    }

    public string GetEmail()
    {
        return this.Email;
    }

    public void SetEmail(string email)
    {
        this.Email = email;
    }

    public string GetUsername()
    {
        return this.Username;
    }

    public void SetUsername(string username)
    {
        this.Username = username;
    }

    public string GetPassword()
    {
        return this.Password;
    }

    public void SetPassword(string password)
    {
        this.Password = password;
    }
}