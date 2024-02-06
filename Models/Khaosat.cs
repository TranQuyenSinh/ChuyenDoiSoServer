using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Khaosat
    {
        public Khaosat()
        {
            ChuyengiaDanhgia = new HashSet<ChuyengiaDanhgium>();
            Danhsachphieu1s = new HashSet<Danhsachphieu1>();
            Danhsachphieu2s = new HashSet<Danhsachphieu2>();
            Danhsachphieu3s = new HashSet<Danhsachphieu3>();
            Danhsachphieu4s = new HashSet<Danhsachphieu4>();
            KhaosatChienluocs = new HashSet<KhaosatChienluoc>();
        }

        public ulong Id { get; set; }
        public DateTime Thoigiantao { get; set; }
        public int Tongdiem { get; set; }
        public int Trangthai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ChuyengiaDanhgium> ChuyengiaDanhgia { get; set; }
        public virtual ICollection<Danhsachphieu1> Danhsachphieu1s { get; set; }
        public virtual ICollection<Danhsachphieu2> Danhsachphieu2s { get; set; }
        public virtual ICollection<Danhsachphieu3> Danhsachphieu3s { get; set; }
        public virtual ICollection<Danhsachphieu4> Danhsachphieu4s { get; set; }
        public virtual ICollection<KhaosatChienluoc> KhaosatChienluocs { get; set; }
    }
}
