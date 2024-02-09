using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Mohinh
    {
        public Mohinh()
        {
            KhaosatChienluoc = new HashSet<KhaosatChienluoc>();
            MohinhLotrinh = new HashSet<MohinhLotrinh>();
        }

        public ulong Id { get; set; }
        public string Tenmohinh { get; set; } = null!;
        public string Noidung { get; set; } = null!;
        public string? Hinhanh { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong MohinhTrucotId { get; set; }
        public ulong DoanhnghiepLoaihinhId { get; set; }

        public virtual DoanhnghiepLoaihinh DoanhnghiepLoaihinh { get; set; } = null!;
        public virtual MohinhTrucot MohinhTrucot { get; set; } = null!;
        public virtual ICollection<KhaosatChienluoc> KhaosatChienluoc { get; set; }
        public virtual ICollection<MohinhLotrinh> MohinhLotrinh { get; set; }
    }
}
