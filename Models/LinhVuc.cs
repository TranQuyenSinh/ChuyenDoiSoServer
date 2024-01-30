using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Linhvuc
    {
        public Linhvuc()
        {
            Doanhnghieps = new HashSet<Doanhnghiep>();
            Tintucs = new HashSet<Tintuc>();
        }

        public int Id { get; set; }
        public string Tenlinhvuc { get; set; } = null!;

        public virtual ICollection<Doanhnghiep> Doanhnghieps { get; set; }
        public virtual ICollection<Tintuc> Tintucs { get; set; }
    }
}
