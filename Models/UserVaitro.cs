using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class UserVaitro
    {
        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public string VaitroId { get; set; } = null!;
        public string CapVaitroId { get; set; } = null!;
        public ulong? DuyetUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Vaitro CapVaitro { get; set; } = null!;
        public virtual Users? DuyetUser { get; set; }
        public virtual Users User { get; set; } = null!;
        public virtual Vaitro Vaitro { get; set; } = null!;
    }
}
