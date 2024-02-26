using System.ComponentModel.DataAnnotations;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Admin.TinTuc.RequestModels;

public class CreateTinTuc
{
    public string LinhvucId { get; set; }

    [Required(ErrorMessage = "Tiêu đề không được để trống ")]
    public string Tieude { get; set; }

    [Required(ErrorMessage = "Tóm tăt không được để trồng")]
    public string Tomtat { get; set; }

    [Required(ErrorMessage = "Nội dung không được để trồng")]
    public string Noidung { get; set; }

    // public CreateTinTuc() { }
    // public CreateTinTuc(Tintuc tt)
    // {
    //     LinhvucId = tt.LinhvucId;
    //     Tieude = tt.Tieude;
    //     Tomtat = tt.Tomtat;
    //     Noidung = tt.Noidung;
    //     Hinhanh = AppPath.GenerateImagePath(AppPath.TIN_TUC_PHOTO, tt.Hinhanh, true);
    // }
}