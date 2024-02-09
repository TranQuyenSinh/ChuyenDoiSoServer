using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class DoanhnghiepLoaihinh
    {
        public DoanhnghiepLoaihinh()
        {
            Doanhnghiep = new HashSet<Doanhnghiep>();
            Mohinh = new HashSet<Mohinh>();
        }

        public ulong Id { get; set; }
        public string LinhvucId { get; set; } = null!;
        public string Tenloaihinh { get; set; } = null!;
        public string? Hinhanh { get; set; }
        public string? Mota { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Linhvuc Linhvuc { get; set; } = null!;
        public virtual ICollection<Doanhnghiep> Doanhnghiep { get; set; }
        public virtual ICollection<Mohinh> Mohinh { get; set; }
    }
}
