using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class HiephoidoanhnghiepDaidien
    {
        public ulong Id { get; set; }
        public ulong HiephoidoanhnghiepId { get; set; }
        public string Tendaidien { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? Mota { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Hiephoidoanhnghiep Hiephoidoanhnghiep { get; set; } = null!;
    }
}
