using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.DoanhNghiep.ResponseModel;

public class DaiDienDoanhNghiepModel
{
    public ulong Id { get; set; }
    public string Tendaidien { get; set; }
    public string Email { get; set; }
    public string Sdt { get; set; }
    public string Diachi { get; set; }
    public string Cccd { get; set; }
    public string ImgMattruoc { get; set; }
    public string ImgMatsau { get; set; }
    public string Chucvu { get; set; }

    public DaiDienDoanhNghiepModel() { }

    public DaiDienDoanhNghiepModel(DoanhnghiepDaidien dndd)
    {
        Id = dndd.Id;
        Tendaidien = dndd.Tendaidien;
        Email = dndd.Email;
        Sdt = dndd.Sdt;
        Diachi = dndd.Diachi;
        Cccd = dndd.Cccd;
        ImgMattruoc = AppPath.GenerateImagePath(AppPath.CCCD, dndd.ImgMattruoc);
        ImgMatsau = AppPath.GenerateImagePath(AppPath.CCCD, dndd.ImgMatsau);
        Chucvu = dndd.Chucvu;
    }
}