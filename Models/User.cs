using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class User
    {
        public User()
        {
            Binhluans = new HashSet<Binhluan>();
            Doanhnghieps = new HashSet<Doanhnghiep>();
            Tintucs = new HashSet<Tintuc>();
            UserVaitros = new HashSet<UserVaitro>();
        }

        public int Id { get; set; }
        public string Hoten { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? ProviderKey { get; set; }
        public sbyte Trangthai { get; set; }

        public virtual ICollection<Binhluan> Binhluans { get; set; }
        public virtual ICollection<Doanhnghiep> Doanhnghieps { get; set; }
        public virtual ICollection<Tintuc> Tintucs { get; set; }
        public virtual ICollection<UserVaitro> UserVaitros { get; set; }
    }
}
