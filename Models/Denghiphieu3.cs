using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Denghiphieu3
    {
        public ulong Id { get; set; }
        public ulong Danhsachphieu3Id { get; set; }
        public string? Noidung { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Danhsachphieu3 Danhsachphieu3 { get; set; } = null!;
    }
}
