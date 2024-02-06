using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Binhluan
    {
        public Binhluan()
        {
            InverseBinhluanNavigation = new HashSet<Binhluan>();
        }

        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public ulong TintucId { get; set; }
        public string Noidung { get; set; } = null!;
        public DateTime Ngaydang { get; set; }
        public ulong? BinhluanId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Binhluan? BinhluanNavigation { get; set; }
        public virtual Tintuc Tintuc { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Binhluan> InverseBinhluanNavigation { get; set; }
    }
}
