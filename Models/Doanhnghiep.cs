using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Doanhnghiep
    {
        public Doanhnghiep()
        {
            DoanhnghiepDaidien = new HashSet<DoanhnghiepDaidien>();
            DoanhnghiepSdt = new HashSet<DoanhnghiepSdt>();
        }

        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public ulong DoanhnghiepLoaihinhId { get; set; }
        public string Tentiengviet { get; set; } = null!;
        public string Tentienganh { get; set; } = null!;
        public string? Tenviettat { get; set; }
        public string? Diachi { get; set; }
        public string? Mathue { get; set; }
        public string? Fax { get; set; }
        public int Soluongnhansu { get; set; }
        public DateTime Ngaylap { get; set; }
        public string? Mota { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual DoanhnghiepLoaihinh DoanhnghiepLoaihinh { get; set; } = null!;
        public virtual Users User { get; set; } = null!;
        public virtual ICollection<DoanhnghiepDaidien> DoanhnghiepDaidien { get; set; }
        public virtual ICollection<DoanhnghiepSdt> DoanhnghiepSdt { get; set; }
    }
}
