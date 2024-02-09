using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.Models;

// Cần include UserVaitro => theninclude VaiTro
public class UserModel
{
    public ulong Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; } = null!;
    public string? Image { get; set; }
    public string Status { get; set; } = null!;

    public List<VaiTroModel> VaiTros { get; set; }

    public UserModel(Users u)
    {
        Id = u.Id;
        Name = u.Name;
        Email = u.Email;
        Image = AppPath.GenerateImagePath(AppPath.USER_PHOTO, u.Image);
        Status = u.Status;
        VaiTros = u.UserVaitro?.Select(x => new VaiTroModel(x.Vaitro)).ToList();
    }
}