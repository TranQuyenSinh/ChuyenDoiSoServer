using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Danhgiaphieu4
    {
        public ulong Id { get; set; }
        public ulong Danhsachphieu4Id { get; set; }
        public string Tendanhgia { get; set; } = null!;
        public string? Noidungnhucau { get; set; }
        public string? Noidungdexuat { get; set; }
        public int Trangthai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Danhsachphieu4 Danhsachphieu4 { get; set; } = null!;
    }
}
