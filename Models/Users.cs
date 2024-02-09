using System;
using System.Collections.Generic;

namespace ChuyenDoiSoServer.Models
{
    public partial class Users
    {
        public Users()
        {
            Binhluan = new HashSet<Binhluan>();
            Chuyengia = new HashSet<Chuyengia>();
            Doanhnghiep = new HashSet<Doanhnghiep>();
            Hiephoidoanhnghiep = new HashSet<Hiephoidoanhnghiep>();
            Tintuc = new HashSet<Tintuc>();
            UserVaitroDuyetUser = new HashSet<UserVaitro>();
            UserVaitroUser = new HashSet<UserVaitro>();
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

        public virtual ICollection<Binhluan> Binhluan { get; set; }
        public virtual ICollection<Chuyengia> Chuyengia { get; set; }
        public virtual ICollection<Doanhnghiep> Doanhnghiep { get; set; }
        public virtual ICollection<Hiephoidoanhnghiep> Hiephoidoanhnghiep { get; set; }
        public virtual ICollection<Tintuc> Tintuc { get; set; }
        public virtual ICollection<UserVaitro> UserVaitroDuyetUser { get; set; }
        public virtual ICollection<UserVaitro> UserVaitroUser { get; set; }
    }
}
