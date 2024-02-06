using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Chuyengium
    {
        public Chuyengium()
        {
            ChuyengiaDanhgia = new HashSet<ChuyengiaDanhgium>();
        }

        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public string LinhvucId { get; set; } = null!;
        public string Tenchuyengia { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? Diachi { get; set; }
        public string Cccd { get; set; } = null!;
        public string ImgMattruoc { get; set; } = null!;
        public string ImgMatsau { get; set; } = null!;
        public string? Mota { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Linhvuc Linhvuc { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<ChuyengiaDanhgium> ChuyengiaDanhgia { get; set; }
    }
}
