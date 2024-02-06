using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Traloiphieu3
    {
        public ulong Id { get; set; }
        public ulong Danhgiaphieu3Id { get; set; }
        public int Diem { get; set; }
        public int Trangthai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong Cauhoiphieu3Id { get; set; }

        public virtual Cauhoiphieu3 Cauhoiphieu3 { get; set; } = null!;
        public virtual Danhgiaphieu3 Danhgiaphieu3 { get; set; } = null!;
    }
}
