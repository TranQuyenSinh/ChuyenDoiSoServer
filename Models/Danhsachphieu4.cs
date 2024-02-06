using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Danhsachphieu4
    {
        public Danhsachphieu4()
        {
            Danhgiaphieu4s = new HashSet<Danhgiaphieu4>();
        }

        public ulong Id { get; set; }
        public ulong KhaosatId { get; set; }
        public int Diem { get; set; }
        public int Soluonghoanthanh { get; set; }
        public string Trangthai { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Khaosat Khaosat { get; set; } = null!;
        public virtual ICollection<Danhgiaphieu4> Danhgiaphieu4s { get; set; }
    }
}
