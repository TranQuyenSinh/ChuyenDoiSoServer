using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.Models;

public class LoaiHinhModel
{
    public ulong? Id { get; set; }
    public string Tenloaihinh { get; set; } = null!;
    public string? Hinhanh { get; set; }
    public string? Mota { get; set; }

    public LoaiHinhModel(DoanhnghiepLoaihinh dnlh)
    {
        Id = dnlh?.Id;
        Tenloaihinh = dnlh?.Tenloaihinh;
        Hinhanh = AppPath.GenerateImagePath(AppPath.LOAI_HINH_PHOTO, dnlh?.Hinhanh);
        Mota = dnlh?.Mota;
    }
}