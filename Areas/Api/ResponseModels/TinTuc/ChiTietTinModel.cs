using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.TinTuc.ResponseModel;

public class ChiTietTinModel
{
    /*
     x.Id,
    x.TieuDe,
    x.NoiDung,
    x.TomTat,
    HinhAnh = AppPath.GenerateImagePath(AppPath.TIN_TUC_PHOTO, x.HinhAnh),
    x.TacGia,
    x.LuotXem,
    x.CreatedAt
    */
    public ulong Id { get; set; }
    public string TieuDe { get; set; }
    public string NoiDung { get; set; }
    public string TomTat { get; set; }
    public string HinhAnh { get; set; }
    public string TacGia { get; set; }
    public string LinhVuc { get; set; }
    public int LuotXem { get; set; }
    public DateTime? CreatedAt { get; set; }

    public ChiTietTinModel(Tintuc tinTuc)
    {
        Id = tinTuc.Id;
        LinhVuc = tinTuc.Linhvuc?.Tenlinhvuc;
        TieuDe = tinTuc.Tieude;
        NoiDung = tinTuc.Noidung;
        TomTat = tinTuc.Tomtat;
        HinhAnh = AppPath.GenerateImagePath(AppPath.TIN_TUC_PHOTO, tinTuc.Hinhanh);
        TacGia = tinTuc.User.Name;
        LuotXem = tinTuc.Luotxem;
        CreatedAt = tinTuc.CreatedAt;
    }
}