using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Cauhoiphieu1
    {
        public Cauhoiphieu1()
        {
            Traloiphieu1 = new HashSet<Traloiphieu1>();
        }

        public ulong Id { get; set; }
        public string Tencauhoi { get; set; } = null!;
        public int Cap { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Traloiphieu1> Traloiphieu1 { get; set; }
    }
}
