using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Danhsachphieu1
    {
        public Danhsachphieu1()
        {
            Danhgiaphieu1 = new HashSet<Danhgiaphieu1>();
        }

        public ulong Id { get; set; }
        public ulong KhaosatId { get; set; }
        public int Diem { get; set; }
        public int Soluonghoanthanh { get; set; }
        public string Trangthai { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Khaosat Khaosat { get; set; } = null!;
        public virtual ICollection<Danhgiaphieu1> Danhgiaphieu1 { get; set; }
    }
}
