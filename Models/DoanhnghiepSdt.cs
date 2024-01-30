using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class DoanhnghiepSdt
    {
        public int Id { get; set; }
        public int IdDoanhnghiep { get; set; }
        public string Sdt { get; set; } = null!;
        public string Loaisdt { get; set; } = null!;

        public virtual Doanhnghiep IdDoanhnghiepNavigation { get; set; } = null!;
    }
}
