using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Khaosat
    {
        public Khaosat()
        {
            ChuyengiaDanhgia = new HashSet<ChuyengiaDanhgia>();
            Danhsachphieu1 = new HashSet<Danhsachphieu1>();
            Danhsachphieu2 = new HashSet<Danhsachphieu2>();
            Danhsachphieu3 = new HashSet<Danhsachphieu3>();
            Danhsachphieu4 = new HashSet<Danhsachphieu4>();
            KhaosatChienluoc = new HashSet<KhaosatChienluoc>();
        }

        public ulong Id { get; set; }
        public ulong DoanhnghiepId { get; set; }
        public DateTime Thoigiantao { get; set; }
        public int Tongdiem { get; set; }
        public int Trangthai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Doanhnghiep Doanhnghiep { get; set; } = null!;
        public virtual ICollection<ChuyengiaDanhgia> ChuyengiaDanhgia { get; set; }
        public virtual ICollection<Danhsachphieu1> Danhsachphieu1 { get; set; }
        public virtual ICollection<Danhsachphieu2> Danhsachphieu2 { get; set; }
        public virtual ICollection<Danhsachphieu3> Danhsachphieu3 { get; set; }
        public virtual ICollection<Danhsachphieu4> Danhsachphieu4 { get; set; }
        public virtual ICollection<KhaosatChienluoc> KhaosatChienluoc { get; set; }
    }
}
