using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Binhluan
    {
        public Binhluan()
        {
            InverseIdBinhluanNavigation = new HashSet<Binhluan>();
        }

        public int Id { get; set; }
        public int? IdBinhluan { get; set; }
        public int IdUser { get; set; }
        public int IdTintuc { get; set; }
        public string Noidung { get; set; } = null!;
        public DateTime Ngaydang { get; set; }

        public virtual Binhluan? IdBinhluanNavigation { get; set; }
        public virtual Tintuc IdTintucNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Binhluan> InverseIdBinhluanNavigation { get; set; }
    }
}
