using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class MohinhLotrinh
    {
        public ulong Id { get; set; }
        public ulong MohinhId { get; set; }
        public string Tenlotrinh { get; set; } = null!;
        public DateTime Thoigian { get; set; }
        public int Nhansu { get; set; }
        public int Taichinh { get; set; }
        public string Noidung { get; set; } = null!;
        public string? Luuy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Mohinh Mohinh { get; set; } = null!;
    }
}
