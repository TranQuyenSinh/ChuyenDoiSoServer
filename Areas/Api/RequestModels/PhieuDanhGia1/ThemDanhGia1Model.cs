namespace ChuyenDoiSoServer.Api.PhieuDanhGia1.RequestModel;

public class ThemDanhGia1Model
{
    public List<Diem> Scores { get; set; }
}

public class Diem
{
    // Tiêu chí 1 Id
    public int Id { get; set; }
    public int Score { get; set; }
}