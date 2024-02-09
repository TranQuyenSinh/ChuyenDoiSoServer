using ChuyenDoiSoServer.Api.DoanhNghiep.RequestModel;
using ChuyenDoiSoServer.Api.Models;
using ChuyenDoiSoServer.Models;

namespace ChuyenDoiSoServer.Api.DoanhNghiep.ResponseModel;

public class DoanhNghiepModel
{
    public string Tentiengviet { get; set; }
    public string Tentienganh { get; set; }
    public string? Tenviettat { get; set; }
    public string? Diachi { get; set; }
    public string? Mathue { get; set; }
    public string? Fax { get; set; }
    public int Soluongnhansu { get; set; }
    public DateTime Ngaylap { get; set; }
    public string? Mota { get; set; }
    public string? Trangthai { get; set; }
    public virtual LoaiHinhModel Loaihinh { get; set; } = null!;
    public virtual List<DienThoaiModel> Dienthoais { get; set; }

    public DoanhNghiepModel(Doanhnghiep dn)
    {
        Tentiengviet = dn.Tentiengviet;
        Tentienganh = dn.Tentienganh;
        Tenviettat = dn.Tenviettat;
        Diachi = dn.Diachi;
        Mathue = dn.Mathue;
        Fax = dn.Fax;
        Soluongnhansu = dn.Soluongnhansu;
        Ngaylap = dn.Ngaylap;
        Mota = dn.Mota;
        Trangthai = dn.User?.Status?.ToLower();

        Loaihinh = new LoaiHinhModel(dn.DoanhnghiepLoaihinh);
        Dienthoais = dn.DoanhnghiepSdt?.Select(x => new DienThoaiModel(x)).ToList();
    }
}