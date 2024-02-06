using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Linhvuc
    {
        public Linhvuc()
        {
            Chuyengia = new HashSet<Chuyengium>();
            DoanhnghiepLoaihinhs = new HashSet<DoanhnghiepLoaihinh>();
            Tintucs = new HashSet<Tintuc>();
        }

        public string Id { get; set; } = null!;
        public string Tenlinhvuc { get; set; } = null!;
        public string? Hinhanh { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Chuyengium> Chuyengia { get; set; }
        public virtual ICollection<DoanhnghiepLoaihinh> DoanhnghiepLoaihinhs { get; set; }
        public virtual ICollection<Tintuc> Tintucs { get; set; }
    }
}
