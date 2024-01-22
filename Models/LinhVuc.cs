using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuyenDoiSoServer.Models;

[Table("LinhVuc")]
public class LinhVuc
{
    [Key]
    public int Id { get; set; }
    [StringLength(255)]
    public string TenLinhVuc { get; set; }
    public string? MoTa { get; set; }

    public List<TinTuc> TinTucs { get; set; }
}