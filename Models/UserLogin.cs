using System.ComponentModel.DataAnnotations;

namespace ChuyenDoiSoServer.Models;

public class UserLogin
{
    public string ProviderName { get; set; }
    public string ProviderKey { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}