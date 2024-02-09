using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Linhvuc
    {
        public Linhvuc()
        {
            Chuyengia = new HashSet<Chuyengia>();
            DoanhnghiepLoaihinh = new HashSet<DoanhnghiepLoaihinh>();
            Tintuc = new HashSet<Tintuc>();
        }

        public string Id { get; set; } = null!;
        public string Tenlinhvuc { get; set; } = null!;
        public string? Hinhanh { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Chuyengia> Chuyengia { get; set; }
        public virtual ICollection<DoanhnghiepLoaihinh> DoanhnghiepLoaihinh { get; set; }
        public virtual ICollection<Tintuc> Tintuc { get; set; }
    }
}
