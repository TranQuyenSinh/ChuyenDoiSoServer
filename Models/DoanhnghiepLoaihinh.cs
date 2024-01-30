using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class DoanhnghiepLoaihinh
    {
        public DoanhnghiepLoaihinh()
        {
            Doanhnghieps = new HashSet<Doanhnghiep>();
        }

        public int Id { get; set; }
        public string Tenloaihinh { get; set; } = null!;

        public virtual ICollection<Doanhnghiep> Doanhnghieps { get; set; }
    }
}
