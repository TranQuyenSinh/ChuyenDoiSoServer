using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;

namespace ChuyenDoiSoServer.Api.HiepHoi.ResponseModel;

public class DaiDienHiepHoiModel
{
    public ulong Id { get; set; }
    public string TenDaiDien { get; set; }
    public string Email { get; set; }
    public string? Sdt { get; set; }
    public string? MoTa { get; set; }

    public DaiDienHiepHoiModel() { }

    public DaiDienHiepHoiModel(HiephoidoanhnghiepDaidien hhdndd)
    {
        Id = hhdndd.Id;
        TenDaiDien = hhdndd.Tendaidien;
        Email = hhdndd.Email;
        Sdt = hhdndd.Sdt;
        MoTa = hhdndd.Mota;
    }
}