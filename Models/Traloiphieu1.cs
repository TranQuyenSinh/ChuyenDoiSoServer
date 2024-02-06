using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Traloiphieu1
    {
        public ulong Id { get; set; }
        public ulong Danhgiaphieu1Id { get; set; }
        public int Diem { get; set; }
        public int Trangthai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong Cauhoiphieu1Id { get; set; }

        public virtual Cauhoiphieu1 Cauhoiphieu1 { get; set; } = null!;
        public virtual Danhgiaphieu1 Danhgiaphieu1 { get; set; } = null!;
    }
}
