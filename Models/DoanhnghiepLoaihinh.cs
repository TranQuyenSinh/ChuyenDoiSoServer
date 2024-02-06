using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class DoanhnghiepLoaihinh
    {
        public DoanhnghiepLoaihinh()
        {
            Doanhnghieps = new HashSet<Doanhnghiep>();
            Mohinhs = new HashSet<Mohinh>();
        }

        public ulong Id { get; set; }
        public string LinhvucId { get; set; } = null!;
        public string Tenloaihinh { get; set; } = null!;
        public string? Hinhanh { get; set; }
        public string? Mota { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Linhvuc Linhvuc { get; set; } = null!;
        public virtual ICollection<Doanhnghiep> Doanhnghieps { get; set; }
        public virtual ICollection<Mohinh> Mohinhs { get; set; }
    }
}
