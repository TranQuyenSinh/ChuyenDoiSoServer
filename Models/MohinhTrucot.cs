using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class MohinhTrucot
    {
        public MohinhTrucot()
        {
            Mohinhs = new HashSet<Mohinh>();
        }

        public ulong Id { get; set; }
        public string Tentrucot { get; set; } = null!;
        public string Noidung { get; set; } = null!;
        public string? Hinhanh { get; set; }
        public string? Ghichu { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Mohinh> Mohinhs { get; set; }
    }
}
