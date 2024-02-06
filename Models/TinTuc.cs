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

        public ulong Id { get; set; }
        public string LinhvucId { get; set; } = null!;
        public ulong UserId { get; set; }
        public string Tieude { get; set; } = null!;
        public string Tomtat { get; set; } = null!;
        public string? Hinhanh { get; set; }
        public string Noidung { get; set; } = null!;
        public int Luotxem { get; set; }
        public sbyte Duyet { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Linhvuc Linhvuc { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Binhluan> Binhluans { get; set; }
    }
}
