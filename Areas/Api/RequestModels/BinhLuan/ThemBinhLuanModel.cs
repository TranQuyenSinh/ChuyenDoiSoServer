using System.ComponentModel.DataAnnotations;

namespace ChuyenDoiSoServer.Api.BinhLuan.RequestModel;

public class ThemBinhLuanModel
{
    public string NoiDung { get; set; }
    public ulong TinTucId { get; set; }
    public ulong UserId { get; set; }
    public ulong? BinhLuanChaId { get; set; } = null;
}