using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.HiepHoi.ResponseModel;

public class HiepHoiDoanhNghiepModel
{
    public ulong Id { get; set; }
    public string TenTiengViet { get; set; }
    public string TenTiengAnh { get; set; }
    public string Sdt { get; set; }
    public string? DiaChi { get; set; }
    public string? MoTa { get; set; }
    public DaiDienHiepHoiModel DaiDien { get; set; }

    public HiepHoiDoanhNghiepModel() { }

    public HiepHoiDoanhNghiepModel(Hiephoidoanhnghiep hhdn)
    {
        Id = hhdn.Id;
        TenTiengViet = hhdn.Tentiengviet;
        TenTiengAnh = hhdn.Tentienganh;
        Sdt = hhdn.Sdt;
        DiaChi = hhdn.Diachi;
        MoTa = hhdn.Mota;
        DaiDien = new DaiDienHiepHoiModel(hhdn.HiephoidoanhnghiepDaidien.FirstOrDefault());
    }
}