using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Danhsachphieu3
    {
        public Danhsachphieu3()
        {
            Danhgiaphieu3s = new HashSet<Danhgiaphieu3>();
            Denghiphieu3s = new HashSet<Denghiphieu3>();
        }

        public ulong Id { get; set; }
        public ulong KhaosatId { get; set; }
        public int Diem { get; set; }
        public int Soluonghoanthanh { get; set; }
        public string Trangthai { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Khaosat Khaosat { get; set; } = null!;
        public virtual ICollection<Danhgiaphieu3> Danhgiaphieu3s { get; set; }
        public virtual ICollection<Denghiphieu3> Denghiphieu3s { get; set; }
    }
}
