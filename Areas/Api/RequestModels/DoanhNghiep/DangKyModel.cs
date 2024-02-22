using System.ComponentModel.DataAnnotations;
using ChuyenDoiSoServer.Api.Models;

namespace ChuyenDoiSoServer.Api.DoanhNghiep.RequestModel;

public class DangKyModel
{
    // Tài khoản
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    // Đại diện
    public string TenNguoiDaiDien { get; set; }
    public string DienThoaiDD { get; set; }
    public string EmailDD { get; set; }
    public string DiaChiDD { get; set; }
    public string Cccd { get; set; }
    // public string NoiCap { get; set; }
    public IFormFile ImgMatTruoc { get; set; }
    public IFormFile ImgMatSau { get; set; }
    public string ChucVu { get; set; }

    // Doanh nghiệp
    public ulong LoaiHinhId { get; set; }
    // public int LinhVucId { get; set; }
    public string TenTiengViet { get; set; }
    public string? TenTiengAnh { get; set; }
    public string? TenVietTat { get; set; }
    // public string EmailDN { get; set; }
    public string DiaChiDN { get; set; }
    public string MaSoThue { get; set; }
    public string? Fax { get; set; }
    public int SoLuongNhanSu { get; set; }
    public DateTime NgayLap { get; set; }
    public string? MoTa { get; set; }

    public List<DienThoaiModel>? DienThoaiDN { get; set; }
}