using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.Models;

public class LinhVucModel
{
    public string Id { get; set; } = null!;
    public string TenLinhVuc { get; set; } = null!;
    public string? HinhAnh { get; set; }

    public LinhVucModel(Linhvuc lv)
    {
        Id = lv.Id;
        TenLinhVuc = lv.Tenlinhvuc;
        HinhAnh = AppPath.GenerateImagePath(AppPath.LINH_VUC_PHOTO, lv.Hinhanh);
    }
}