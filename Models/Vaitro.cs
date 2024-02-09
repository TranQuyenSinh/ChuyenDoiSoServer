using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Vaitro
    {
        public Vaitro()
        {
            UserVaitro = new HashSet<UserVaitro>();
        }

        public string Id { get; set; } = null!;
        public string Tenvaitro { get; set; } = null!;
        public string? Hinhanh { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserVaitro> UserVaitro { get; set; }
    }
}
