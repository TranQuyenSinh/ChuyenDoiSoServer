using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.Models;

public class LoaiHinhModel
{
    public ulong? Id { get; set; }
    public string TenLoaiHinh { get; set; } = null!;
    public string? HinhAnh { get; set; }
    public string? MoTa { get; set; }

    public LoaiHinhModel(DoanhnghiepLoaihinh dnlh)
    {
        Id = dnlh.Id;
        TenLoaiHinh = dnlh.Tenloaihinh;
        HinhAnh = AppPath.GenerateImagePath(AppPath.LOAI_HINH_PHOTO, dnlh?.Hinhanh); ;
        MoTa = dnlh.Mota;
    }
}