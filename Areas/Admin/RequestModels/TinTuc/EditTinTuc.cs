using System.ComponentModel.DataAnnotations;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Admin.TinTuc.RequestModels;

public class EditTinTuc
{

    public ulong Id { get; set; }
    public string LinhvucId { get; set; }

    [Required(ErrorMessage = "Tiêu đề không được để trống ")]
    public string Tieude { get; set; }

    [Required(ErrorMessage = "Tóm tăt không được để trồng")]
    public string Tomtat { get; set; }

    [Required(ErrorMessage = "Nội dung không được để trồng")]
    public string Noidung { get; set; }

    public string? Hinhanh { get; set; }

    public EditTinTuc() { }
    public EditTinTuc(Tintuc tt)
    {
        Id = tt.Id;
        LinhvucId = tt.LinhvucId;
        Tieude = tt.Tieude;
        Tomtat = tt.Tomtat;
        Noidung = tt.Noidung;
        Hinhanh = AppPath.GenerateImagePath(AppPath.TIN_TUC_PHOTO, tt.Hinhanh, true);
    }
}