namespace ChuyenDoiSoServer.Admin.Models;

[Serializable]
public class UserSession
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public List<string> Roles { get; set; }
}