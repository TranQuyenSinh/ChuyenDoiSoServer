using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Tintuc
    {
        public Tintuc()
        {
            Binhluans = new HashSet<Binhluan>();
        }

        public int Id { get; set; }
        public int IdLinhvuc { get; set; }
        public int IdUser { get; set; }
        public string Tieude { get; set; } = null!;
        public string Tomtat { get; set; } = null!;
        public string Noidung { get; set; } = null!;
        public string Hinhanh { get; set; } = null!;
        public DateTime Ngaydang { get; set; }
        public int Luotxem { get; set; }
        public sbyte Trangthai { get; set; }

        public virtual Linhvuc IdLinhvucNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Binhluan> Binhluans { get; set; }
    }
}
