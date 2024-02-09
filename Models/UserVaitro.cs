using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class UserVaitro
    {
        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public string VaitroId { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Users User { get; set; } = null!;
        public virtual Vaitro Vaitro { get; set; } = null!;
    }
}
