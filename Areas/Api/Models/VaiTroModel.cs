using ChuyenDoiSoServer.Models;

namespace ChuyenDoiSoServer.Api.Models;

public class VaiTroModel
{
    public string Id { get; set; }
    public string TenVaiTro { get; set; }

    public VaiTroModel(Vaitro vt)
    {
        Id = vt.Id;
        TenVaiTro = vt.Tenvaitro;
    }
}