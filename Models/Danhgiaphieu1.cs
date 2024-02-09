using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Danhgiaphieu1
    {
        public Danhgiaphieu1()
        {
            Traloiphieu1 = new HashSet<Traloiphieu1>();
        }

        public ulong Id { get; set; }
        public ulong Danhsachphieu1Id { get; set; }
        public string Tendanhgia { get; set; } = null!;
        public int Diem { get; set; }
        public string Trangthai { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Danhsachphieu1 Danhsachphieu1 { get; set; } = null!;
        public virtual ICollection<Traloiphieu1> Traloiphieu1 { get; set; }
    }
}
