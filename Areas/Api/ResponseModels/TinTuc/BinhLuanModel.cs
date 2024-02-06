using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.TinTuc.ResponseModel;

public class BinhLuanModel
{
    public ulong Id { get; set; }
    public string NoiDung { get; set; }
    public string HoTen { get; set; }
    public List<BinhLuanModel> PhanHois { get; set; } = new List<BinhLuanModel>();
    public DateTime CreatedAt { get; set; }

    public BinhLuanModel(Models.Binhluan binhLuan)
    {
        Id = binhLuan.Id;
        NoiDung = binhLuan.Noidung;
        HoTen = binhLuan.User?.Name;
        PhanHois = binhLuan.InverseBinhluanNavigation
                    .Select(x => new BinhLuanModel(x))
                    .OrderByDescending(x => x.CreatedAt).ToList();
        CreatedAt = binhLuan.Ngaydang;
    }
}