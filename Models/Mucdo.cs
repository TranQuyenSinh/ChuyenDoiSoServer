using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Mucdo
    {
        public Mucdo()
        {
            KhaosatChienluoc = new HashSet<KhaosatChienluoc>();
        }

        public ulong Id { get; set; }
        public string Tenmucdo { get; set; } = null!;
        public string Noidung { get; set; } = null!;
        public int Diem { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<KhaosatChienluoc> KhaosatChienluoc { get; set; }
    }
}
