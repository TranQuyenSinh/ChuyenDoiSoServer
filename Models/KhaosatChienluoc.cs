using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class KhaosatChienluoc
    {
        public ulong Id { get; set; }
        public ulong KhaosatId { get; set; }
        public ulong MucdoId { get; set; }
        public ulong MohinhId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Khaosat Khaosat { get; set; } = null!;
        public virtual Mohinh Mohinh { get; set; } = null!;
        public virtual Mucdo Mucdo { get; set; } = null!;
    }
}
