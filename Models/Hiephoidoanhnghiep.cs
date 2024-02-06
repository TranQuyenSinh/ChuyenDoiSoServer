using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Hiephoidoanhnghiep
    {
        public Hiephoidoanhnghiep()
        {
            HiephoidoanhnghiepDaidiens = new HashSet<HiephoidoanhnghiepDaidien>();
        }

        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public string Tentiengviet { get; set; } = null!;
        public string Tentienganh { get; set; } = null!;
        public string Sdt { get; set; } = null!;
        public string? Diachi { get; set; }
        public string? Mota { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<HiephoidoanhnghiepDaidien> HiephoidoanhnghiepDaidiens { get; set; }
    }
}
