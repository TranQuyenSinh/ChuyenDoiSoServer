using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Danhgiaphieu2
    {
        public Danhgiaphieu2()
        {
            Traloiphieu2s = new HashSet<Traloiphieu2>();
        }

        public ulong Id { get; set; }
        public ulong Danhsachphieu2Id { get; set; }
        public string Tendanhgia { get; set; } = null!;
        public int Diem { get; set; }
        public string Trangthai { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Danhsachphieu2 Danhsachphieu2 { get; set; } = null!;
        public virtual ICollection<Traloiphieu2> Traloiphieu2s { get; set; }
    }
}
