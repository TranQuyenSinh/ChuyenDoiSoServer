using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class DoanhnghiepSdt
    {
        public ulong Id { get; set; }
        public ulong DoanhnghiepId { get; set; }
        public string Sdt { get; set; } = null!;
        public string Loaisdt { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Doanhnghiep Doanhnghiep { get; set; } = null!;
    }
}
