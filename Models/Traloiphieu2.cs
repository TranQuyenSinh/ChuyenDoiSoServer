using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Traloiphieu2
    {
        public ulong Id { get; set; }
        public ulong Danhgiaphieu2Id { get; set; }
        public int Diem { get; set; }
        public int Trangthai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong Cauhoiphieu2Id { get; set; }

        public virtual Cauhoiphieu2 Cauhoiphieu2 { get; set; } = null!;
        public virtual Danhgiaphieu2 Danhgiaphieu2 { get; set; } = null!;
    }
}
