using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.TinTuc.ResponseModel;

public class BinhLuanModel
{

    public int Id { get; set; }
    public string NoiDung { get; set; }
    public string HoTen { get; set; }
    public List<BinhLuanModel> PhanHois { get; set; } = new List<BinhLuanModel>();
    public DateTime CreatedAt { get; set; }

    public BinhLuanModel(Models.BinhLuan binhLuan)
    {
        Id = binhLuan.Id;
        NoiDung = binhLuan.NoiDung;
        HoTen = binhLuan.User.FirstName + " " + binhLuan.User.LastName;
        PhanHois = binhLuan.PhanHois.Select(x => new BinhLuanModel(x)).OrderByDescending(x => x.CreatedAt).ToList();
        CreatedAt = binhLuan.CreatedAt;
    }
}