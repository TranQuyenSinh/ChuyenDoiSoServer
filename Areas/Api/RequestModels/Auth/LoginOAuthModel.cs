namespace ChuyenDoiSoServer.Api.Auth.RequestModel;

public class LoginOAuthModel
{
    public string ProviderKey { get; set; }
    public string ProviderName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Photo { get; set; }
}