namespace ChuyenDoiSoServer.Api.Auth.RequestModel;

public class CreateOAuthPasswordModel : LoginNoPasswordModel
{
    public string Password { get; set; }
}