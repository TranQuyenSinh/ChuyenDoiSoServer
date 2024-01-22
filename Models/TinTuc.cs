using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuyenDoiSoServer.Models;

[Table("TinTuc")]
public class TinTuc
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string TieuDe { get; set; }

    [StringLength(int.MaxValue)]
    public string TomTat { get; set; }

    [StringLength(100)]
    public string TacGia { get; set; }

    [StringLength(int.MaxValue)]
    public string NoiDung { get; set; }

    [StringLength(255)]
    public string? HinhAnh { get; set; }

    public int LuotXem { get; set; } = 0;

    public byte TrangThai { get; set; } = 0;

    public int LinhVucId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public LinhVuc LinhVuc { get; set; }
    public List<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();
}