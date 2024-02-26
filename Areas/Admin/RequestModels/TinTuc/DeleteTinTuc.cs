using System.ComponentModel.DataAnnotations;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Admin.TinTuc.RequestModels;

public class DeleteTinTuc
{

    public ulong Id { get; set; }
    public string Tieude { get; set; }
    public string Tomtat { get; set; }
    public string Noidung { get; set; }
    public string? Hinhanh { get; set; }
    public string Tacgia { get; set; }

    public DeleteTinTuc() { }
    public DeleteTinTuc(Tintuc tt)
    {
        Id = tt.Id;
        Tieude = tt.Tieude;
        Tomtat = tt.Tomtat;
        Noidung = tt.Noidung;
        Tacgia = tt.User?.Name;
        Hinhanh = AppPath.GenerateImagePath(AppPath.TIN_TUC_PHOTO, tt.Hinhanh, true);
    }
}