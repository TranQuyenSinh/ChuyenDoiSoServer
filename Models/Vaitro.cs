using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Vaitro
    {
        public Vaitro()
        {
            UserVaitros = new HashSet<UserVaitro>();
        }

        public int Id { get; set; }
        public string Tenvaitro { get; set; } = null!;

        public virtual ICollection<UserVaitro> UserVaitros { get; set; }
    }
}
