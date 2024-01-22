using System.ComponentModel.DataAnnotations;

namespace ChuyenDoiSoServer.Api.BinhLuan.RequestModel;

public class ThemBinhLuanModel
{
    public string NoiDung { get; set; }
    public int TinTucId { get; set; }
    public int UserId { get; set; }
    public int? BinhLuanChaId { get; set; } = null;
}