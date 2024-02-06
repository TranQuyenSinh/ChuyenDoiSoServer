using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class User
    {
        public User()
        {
            Binhluans = new HashSet<Binhluan>();
            Chuyengia = new HashSet<Chuyengium>();
            Doanhnghieps = new HashSet<Doanhnghiep>();
            Hiephoidoanhnghieps = new HashSet<Hiephoidoanhnghiep>();
            Tintucs = new HashSet<Tintuc>();
            UserVaitroDuyetUsers = new HashSet<UserVaitro>();
            UserVaitroUsers = new HashSet<UserVaitro>();
        }

        public ulong Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public DateTime? EmailVerifiedAt { get; set; }
        public string Password { get; set; } = null!;
        public string? Image { get; set; }
        public string Status { get; set; } = null!;
        public string? RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Binhluan> Binhluans { get; set; }
        public virtual ICollection<Chuyengium> Chuyengia { get; set; }
        public virtual ICollection<Doanhnghiep> Doanhnghieps { get; set; }
        public virtual ICollection<Hiephoidoanhnghiep> Hiephoidoanhnghieps { get; set; }
        public virtual ICollection<Tintuc> Tintucs { get; set; }
        public virtual ICollection<UserVaitro> UserVaitroDuyetUsers { get; set; }
        public virtual ICollection<UserVaitro> UserVaitroUsers { get; set; }
    }
}
