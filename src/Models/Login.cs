class Login
{
    private string Email;
    private string Password;

    public Login (string email, string password)
    {
        this.Email = email;
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

    public string GetPassword()
    {
        return this.Password;
    }

    public void SetPassword(string password)
    {
        this.Password = password;
    }
}