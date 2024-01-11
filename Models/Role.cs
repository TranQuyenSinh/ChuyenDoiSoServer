using System.ComponentModel.DataAnnotations;

namespace ChuyenDoiSoServer.Models;

public class Role
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string RoleName { get; set; }
}