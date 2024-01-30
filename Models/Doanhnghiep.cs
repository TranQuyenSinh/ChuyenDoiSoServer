using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Doanhnghiep
    {
        public Doanhnghiep()
        {
            DoanhnghiepDaidiens = new HashSet<DoanhnghiepDaidien>();
            DoanhnghiepSdts = new HashSet<DoanhnghiepSdt>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdLoaihinh { get; set; }
        public int IdLinhvuc { get; set; }
        public string Tentiengviet { get; set; } = null!;
        public string Tentienganh { get; set; } = null!;
        public string Tenviettat { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Diachi { get; set; } = null!;
        public string Mathue { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public int Soluongnhansu { get; set; }
        public DateTime Ngaylap { get; set; }
        public string? Mota { get; set; }

        public virtual Linhvuc IdLinhvucNavigation { get; set; } = null!;
        public virtual DoanhnghiepLoaihinh IdLoaihinhNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<DoanhnghiepDaidien> DoanhnghiepDaidiens { get; set; }
        public virtual ICollection<DoanhnghiepSdt> DoanhnghiepSdts { get; set; }
    }
}
