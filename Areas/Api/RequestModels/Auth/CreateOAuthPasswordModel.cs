namespace ChuyenDoiSoServer.Api.Auth.RequestModel;

public class CreateOAuthPasswordModel : LoginOAuthModel
{
    public string Password { get; set; }
}