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
    public int Id { get; set; }
    public string TieuDe { get; set; }
    public string NoiDung { get; set; }
    public string TomTat { get; set; }
    public string HinhAnh { get; set; }
    public string TacGia { get; set; }
    public int LuotXem { get; set; }
    public DateTime CreatedAt { get; set; }

    public ChiTietTinModel(Models.TinTuc tinTuc)
    {
        Id = tinTuc.Id;
        TieuDe = tinTuc.TieuDe;
        NoiDung = tinTuc.NoiDung;
        TomTat = tinTuc.TomTat;
        HinhAnh = AppPath.GenerateImagePath(AppPath.TIN_TUC_PHOTO, tinTuc.HinhAnh);
        TacGia = tinTuc.TacGia;
        LuotXem = tinTuc.LuotXem;
        CreatedAt = tinTuc.CreatedAt;
    }
}