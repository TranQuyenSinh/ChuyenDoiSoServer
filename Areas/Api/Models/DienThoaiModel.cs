using ChuyenDoiSoServer.Models;

namespace ChuyenDoiSoServer.Api.Models;

public class DienThoaiModel
{
    public ulong Id { get; set; }
    public string Sdt { get; set; }
    public string Loaisdt { get; set; }

    public DienThoaiModel() { }

    public DienThoaiModel(DoanhnghiepSdt dnsdt)
    {
        Id = dnsdt.Id;
        Sdt = dnsdt.Sdt;
        Loaisdt = dnsdt.Loaisdt;
    }
}