using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Cauhoiphieu2
    {
        public Cauhoiphieu2()
        {
            Traloiphieu2s = new HashSet<Traloiphieu2>();
        }

        public ulong Id { get; set; }
        public string Tencauhoi { get; set; } = null!;
        public int Cap { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Traloiphieu2> Traloiphieu2s { get; set; }
    }
}
