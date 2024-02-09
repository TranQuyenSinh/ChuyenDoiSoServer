using ChuyenDoiSoServer.Api.Models;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.ChuyenGia.ResponseModel;

public class ChuyenGiaModel
{
    public ulong Id { get; set; }
    public string TenChuyenGia { get; set; } = null!;
    public string HinhAnh { get; set; }
    public string Email { get; set; } = null!;
    public string? Sdt { get; set; }
    public string? DiaChi { get; set; }
    public string? MoTa { get; set; }

    public LinhVucModel LinhVuc { get; set; } = null!;

    public ChuyenGiaModel(Chuyengia cg)
    {
        Id = cg.Id;
        TenChuyenGia = cg.Tenchuyengia;
        HinhAnh = AppPath.GenerateImagePath(AppPath.USER_PHOTO, cg.User?.Image);
        Email = cg.Email;
        Sdt = cg.Sdt;
        DiaChi = cg.Diachi;
        MoTa = cg.Mota;
        LinhVuc = new LinhVucModel(cg.Linhvuc);
    }
}
