using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Danhgiaphieu3
    {
        public Danhgiaphieu3()
        {
            Traloiphieu3 = new HashSet<Traloiphieu3>();
        }

        public ulong Id { get; set; }
        public ulong Danhsachphieu3Id { get; set; }
        public string Tendanhgia { get; set; } = null!;
        public int Diem { get; set; }
        public string Trangthai { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Danhsachphieu3 Danhsachphieu3 { get; set; } = null!;
        public virtual ICollection<Traloiphieu3> Traloiphieu3 { get; set; }
    }
}
