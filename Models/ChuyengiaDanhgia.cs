using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class ChuyengiaDanhgia
    {
        public ulong Id { get; set; }
        public ulong ChuyengiaId { get; set; }
        public ulong KhaosatId { get; set; }
        public string Danhgia { get; set; } = null!;
        public string? Dexuat { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Chuyengia Chuyengia { get; set; } = null!;
        public virtual Khaosat Khaosat { get; set; } = null!;
    }
}
