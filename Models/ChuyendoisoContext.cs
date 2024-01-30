using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChuyenDoiSoServer.Models
{
    public partial class ChuyendoisoContext : DbContext
    {
        public ChuyendoisoContext()
        {
        }

        public ChuyendoisoContext(DbContextOptions<ChuyendoisoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Binhluan> Binhluans { get; set; } = null!;
        public virtual DbSet<Doanhnghiep> Doanhnghieps { get; set; } = null!;
        public virtual DbSet<DoanhnghiepDaidien> DoanhnghiepDaidiens { get; set; } = null!;
        public virtual DbSet<DoanhnghiepLoaihinh> DoanhnghiepLoaihinhs { get; set; } = null!;
        public virtual DbSet<DoanhnghiepSdt> DoanhnghiepSdts { get; set; } = null!;
        public virtual DbSet<Linhvuc> Linhvucs { get; set; } = null!;
        public virtual DbSet<Tintuc> Tintucs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserVaitro> UserVaitros { get; set; } = null!;
        public virtual DbSet<Vaitro> Vaitros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=chuyendoiso;user=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Binhluan>(entity =>
            {
                entity.ToTable("binhluan");

                entity.HasIndex(e => e.IdTintuc, "binhluan_tintuc_idx");

                entity.HasIndex(e => e.IdUser, "binhluan_user_idx");

                entity.HasIndex(e => e.IdBinhluan, "binhluancha_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdBinhluan)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_binhluan")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTintuc)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tintuc");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.Ngaydang)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaydang");

                entity.Property(e => e.Noidung)
                    .HasColumnType("text")
                    .HasColumnName("noidung");

                entity.HasOne(d => d.IdBinhluanNavigation)
                    .WithMany(p => p.InverseIdBinhluanNavigation)
                    .HasForeignKey(d => d.IdBinhluan)
                    .HasConstraintName("binhluancha");

                entity.HasOne(d => d.IdTintucNavigation)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.IdTintuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("binhluan_tintuc");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("binhluan_user");
            });

            modelBuilder.Entity<Doanhnghiep>(entity =>
            {
                entity.ToTable("doanhnghiep");

                entity.HasIndex(e => e.IdLinhvuc, "id_linhvuc_idx");

                entity.HasIndex(e => e.IdLoaihinh, "id_loaihinh");

                entity.HasIndex(e => e.IdUser, "id_user_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(255)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .HasColumnName("fax");

                entity.Property(e => e.IdLinhvuc)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_linhvuc");

                entity.Property(e => e.IdLoaihinh)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_loaihinh");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.Mathue)
                    .HasMaxLength(20)
                    .HasColumnName("mathue");

                entity.Property(e => e.Mota)
                    .HasMaxLength(255)
                    .HasColumnName("mota")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ngaylap)
                    .HasColumnType("date")
                    .HasColumnName("ngaylap");

                entity.Property(e => e.Soluongnhansu)
                    .HasColumnType("int(11)")
                    .HasColumnName("soluongnhansu");

                entity.Property(e => e.Tentienganh)
                    .HasMaxLength(255)
                    .HasColumnName("tentienganh");

                entity.Property(e => e.Tentiengviet)
                    .HasMaxLength(255)
                    .HasColumnName("tentiengviet");

                entity.Property(e => e.Tenviettat)
                    .HasMaxLength(255)
                    .HasColumnName("tenviettat");

                entity.HasOne(d => d.IdLinhvucNavigation)
                    .WithMany(p => p.Doanhnghieps)
                    .HasForeignKey(d => d.IdLinhvuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_linhvuc");

                entity.HasOne(d => d.IdLoaihinhNavigation)
                    .WithMany(p => p.Doanhnghieps)
                    .HasForeignKey(d => d.IdLoaihinh)
                    .HasConstraintName("id_loaihinh");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Doanhnghieps)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("id_user");
            });

            modelBuilder.Entity<DoanhnghiepDaidien>(entity =>
            {
                entity.ToTable("doanhnghiep_daidien");

                entity.HasIndex(e => e.IdDoanhnghiep, "id_doanhnghiep_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(20)
                    .HasColumnName("cccd");

                entity.Property(e => e.Chucvu)
                    .HasMaxLength(255)
                    .HasColumnName("chucvu");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(255)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.IdDoanhnghiep)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_doanhnghiep");

                entity.Property(e => e.ImgMatsau)
                    .HasMaxLength(255)
                    .HasColumnName("img_matsau");

                entity.Property(e => e.ImgMattruoc)
                    .HasMaxLength(255)
                    .HasColumnName("img_mattruoc");

                entity.Property(e => e.Noicap)
                    .HasMaxLength(255)
                    .HasColumnName("noicap");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("sdt");

                entity.Property(e => e.Tennguoidaidien)
                    .HasMaxLength(255)
                    .HasColumnName("tennguoidaidien");

                entity.HasOne(d => d.IdDoanhnghiepNavigation)
                    .WithMany(p => p.DoanhnghiepDaidiens)
                    .HasForeignKey(d => d.IdDoanhnghiep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doanhnghiep_daidien");
            });

            modelBuilder.Entity<DoanhnghiepLoaihinh>(entity =>
            {
                entity.ToTable("doanhnghiep_loaihinh");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Tenloaihinh)
                    .HasMaxLength(255)
                    .HasColumnName("tenloaihinh");
            });

            modelBuilder.Entity<DoanhnghiepSdt>(entity =>
            {
                entity.ToTable("doanhnghiep_sdt");

                entity.HasIndex(e => e.IdDoanhnghiep, "id_doanhnghiep_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdDoanhnghiep)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_doanhnghiep");

                entity.Property(e => e.Loaisdt)
                    .HasMaxLength(20)
                    .HasColumnName("loaisdt");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("sdt");

                entity.HasOne(d => d.IdDoanhnghiepNavigation)
                    .WithMany(p => p.DoanhnghiepSdts)
                    .HasForeignKey(d => d.IdDoanhnghiep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_doanhnghiep");
            });

            modelBuilder.Entity<Linhvuc>(entity =>
            {
                entity.ToTable("linhvuc");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Tenlinhvuc)
                    .HasMaxLength(255)
                    .HasColumnName("tenlinhvuc");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.ToTable("tintuc");

                entity.HasIndex(e => e.IdLinhvuc, "tintuc_linhvuc_idx");

                entity.HasIndex(e => e.IdUser, "tintuc_tacgia_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(255)
                    .HasColumnName("hinhanh");

                entity.Property(e => e.IdLinhvuc)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_linhvuc");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.Luotxem)
                    .HasColumnType("int(11)")
                    .HasColumnName("luotxem");

                entity.Property(e => e.Ngaydang)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaydang");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tieude)
                    .HasMaxLength(255)
                    .HasColumnName("tieude");

                entity.Property(e => e.Tomtat)
                    .HasColumnType("text")
                    .HasColumnName("tomtat");

                entity.Property(e => e.Trangthai)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("trangthai");

                entity.HasOne(d => d.IdLinhvucNavigation)
                    .WithMany(p => p.Tintucs)
                    .HasForeignKey(d => d.IdLinhvuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tintuc_linhvuc");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Tintucs)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tintuc_tacgia");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(255)
                    .HasColumnName("hoten");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(255)
                    .HasColumnName("provider_key")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Trangthai)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("trangthai");
            });

            modelBuilder.Entity<UserVaitro>(entity =>
            {
                entity.ToTable("user_vaitro");

                entity.HasIndex(e => e.IdUser, "id_user_idx");

                entity.HasIndex(e => e.IdVaitro, "id_vaitro_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.IdVaitro)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_vaitro");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserVaitros)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_user_vaitro");

                entity.HasOne(d => d.IdVaitroNavigation)
                    .WithMany(p => p.UserVaitros)
                    .HasForeignKey(d => d.IdVaitro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vaitro_user_vaitro");
            });

            modelBuilder.Entity<Vaitro>(entity =>
            {
                entity.ToTable("vaitro");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Tenvaitro)
                    .HasMaxLength(255)
                    .HasColumnName("tenvaitro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
