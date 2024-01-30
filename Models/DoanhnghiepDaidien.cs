using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class DoanhnghiepDaidien
    {
        public int Id { get; set; }
        public int IdDoanhnghiep { get; set; }
        public string Tennguoidaidien { get; set; } = null!;
        public string Sdt { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Diachi { get; set; } = null!;
        public string Cccd { get; set; } = null!;
        public string Noicap { get; set; } = null!;
        public string ImgMattruoc { get; set; } = null!;
        public string ImgMatsau { get; set; } = null!;
        public string Chucvu { get; set; } = null!;

        public virtual Doanhnghiep IdDoanhnghiepNavigation { get; set; } = null!;
    }
}
