using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuyenDoiSoServer.Models;

[Table("BinhLuan")]
public class BinhLuan
{
    [Key]
    public int Id { get; set; }
    [StringLength(int.MaxValue)]
    public string NoiDung { get; set; }

    public int TinTucId { get; set; }
    public TinTuc TinTuc { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int? BinhLuanChaId { get; set; }
    [ForeignKey("BinhLuanChaId")]
    public BinhLuan? BinhLuanCha { get; set; }
    public List<BinhLuan> PhanHois { get; set; } = new List<BinhLuan>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}