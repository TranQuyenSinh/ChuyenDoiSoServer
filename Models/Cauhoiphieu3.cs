using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Cauhoiphieu3
    {
        public Cauhoiphieu3()
        {
            Traloiphieu3s = new HashSet<Traloiphieu3>();
        }

        public ulong Id { get; set; }
        public string Tencauhoi { get; set; } = null!;
        public int Cap { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Traloiphieu3> Traloiphieu3s { get; set; }
    }
}
