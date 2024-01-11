using System.ComponentModel.DataAnnotations;

namespace ChuyenDoiSoServer.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    /* ================ Auth ================ */
    [StringLength(255)]
    public string FirstName { get; set; }
    [StringLength(255)]
    public string LastName { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    [StringLength(255)]
    public string Password { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }

    // public string? RefreshToken { get; set; }
    // public DateTime RefreshTokenExpiryTime { get; set; }

    /* ================ Personal information ================ */

    [StringLength(255)]
    public string? Phone { get; set; }

    public string? Photo { get; set; }

    // [StringLength(255)]
    // public string? Address { get; set; }
    // public string? Description { get; set; }
    // public bool? Gender { get; set; }
    // public bool IsLocked { get; set; } = false;
    // public DateTime? DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}