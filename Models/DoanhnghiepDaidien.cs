﻿using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class DoanhnghiepDaidien
    {
        public ulong Id { get; set; }
        public ulong DoanhnghiepId { get; set; }
        public string Tendaidien { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? Diachi { get; set; }
        public string Cccd { get; set; } = null!;
        public string ImgMattruoc { get; set; } = null!;
        public string ImgMatsau { get; set; } = null!;
        public string Chucvu { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Doanhnghiep Doanhnghiep { get; set; } = null!;
    }
}
