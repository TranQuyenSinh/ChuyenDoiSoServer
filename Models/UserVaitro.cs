using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class UserVaitro
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdVaitro { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual Vaitro IdVaitroNavigation { get; set; } = null!;
    }
}
