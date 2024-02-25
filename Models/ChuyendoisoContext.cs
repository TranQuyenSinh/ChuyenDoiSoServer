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

        public virtual DbSet<Binhluan> Binhluan { get; set; } = null!;
        public virtual DbSet<Cauhoiphieu1> Cauhoiphieu1 { get; set; } = null!;
        public virtual DbSet<Cauhoiphieu2> Cauhoiphieu2 { get; set; } = null!;
        public virtual DbSet<Cauhoiphieu3> Cauhoiphieu3 { get; set; } = null!;
        public virtual DbSet<Chuyengia> Chuyengia { get; set; } = null!;
        public virtual DbSet<ChuyengiaDanhgia> ChuyengiaDanhgia { get; set; } = null!;
        public virtual DbSet<Danhgiaphieu1> Danhgiaphieu1 { get; set; } = null!;
        public virtual DbSet<Danhgiaphieu2> Danhgiaphieu2 { get; set; } = null!;
        public virtual DbSet<Danhgiaphieu3> Danhgiaphieu3 { get; set; } = null!;
        public virtual DbSet<Danhgiaphieu4> Danhgiaphieu4 { get; set; } = null!;
        public virtual DbSet<Danhsachphieu1> Danhsachphieu1 { get; set; } = null!;
        public virtual DbSet<Danhsachphieu2> Danhsachphieu2 { get; set; } = null!;
        public virtual DbSet<Danhsachphieu3> Danhsachphieu3 { get; set; } = null!;
        public virtual DbSet<Danhsachphieu4> Danhsachphieu4 { get; set; } = null!;
        public virtual DbSet<Denghiphieu3> Denghiphieu3 { get; set; } = null!;
        public virtual DbSet<Doanhnghiep> Doanhnghiep { get; set; } = null!;
        public virtual DbSet<DoanhnghiepDaidien> DoanhnghiepDaidien { get; set; } = null!;
        public virtual DbSet<DoanhnghiepLoaihinh> DoanhnghiepLoaihinh { get; set; } = null!;
        public virtual DbSet<DoanhnghiepSdt> DoanhnghiepSdt { get; set; } = null!;
        public virtual DbSet<Hiephoidoanhnghiep> Hiephoidoanhnghiep { get; set; } = null!;
        public virtual DbSet<HiephoidoanhnghiepDaidien> HiephoidoanhnghiepDaidien { get; set; } = null!;
        public virtual DbSet<Khaosat> Khaosat { get; set; } = null!;
        public virtual DbSet<KhaosatChienluoc> KhaosatChienluoc { get; set; } = null!;
        public virtual DbSet<Linhvuc> Linhvuc { get; set; } = null!;
        public virtual DbSet<Mohinh> Mohinh { get; set; } = null!;
        public virtual DbSet<MohinhLotrinh> MohinhLotrinh { get; set; } = null!;
        public virtual DbSet<MohinhTrucot> MohinhTrucot { get; set; } = null!;
        public virtual DbSet<Mucdo> Mucdo { get; set; } = null!;
        public virtual DbSet<Tintuc> Tintuc { get; set; } = null!;
        public virtual DbSet<Traloiphieu1> Traloiphieu1 { get; set; } = null!;
        public virtual DbSet<Traloiphieu2> Traloiphieu2 { get; set; } = null!;
        public virtual DbSet<Traloiphieu3> Traloiphieu3 { get; set; } = null!;
        public virtual DbSet<UserVaitro> UserVaitro { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;
        public virtual DbSet<Vaitro> Vaitro { get; set; } = null!;

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

                entity.HasIndex(e => e.BinhluanId, "binhluan_binhluan_id_index");

                entity.HasIndex(e => e.TintucId, "binhluan_tintuc_id_index");

                entity.HasIndex(e => e.UserId, "binhluan_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BinhluanId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("binhluan_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ngaydang)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaydang");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.TintucId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("tintuc_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.BinhluanNavigation)
                    .WithMany(p => p.InverseBinhluanNavigation)
                    .HasForeignKey(d => d.BinhluanId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("binhluan_binhluan_id_foreign");

                entity.HasOne(d => d.Tintuc)
                    .WithMany(p => p.Binhluan)
                    .HasForeignKey(d => d.TintucId)
                    .HasConstraintName("binhluan_tintuc_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Binhluan)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("binhluan_user_id_foreign");
            });

            modelBuilder.Entity<Cauhoiphieu1>(entity =>
            {
                entity.ToTable("cauhoiphieu1");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cap)
                    .HasColumnType("int(11)")
                    .HasColumnName("cap");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tencauhoi).HasColumnName("tencauhoi");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Cauhoiphieu2>(entity =>
            {
                entity.ToTable("cauhoiphieu2");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cap)
                    .HasColumnType("int(11)")
                    .HasColumnName("cap");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tencauhoi).HasColumnName("tencauhoi");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Cauhoiphieu3>(entity =>
            {
                entity.ToTable("cauhoiphieu3");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cap)
                    .HasColumnType("int(11)")
                    .HasColumnName("cap");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tencauhoi).HasColumnName("tencauhoi");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Chuyengia>(entity =>
            {
                entity.ToTable("chuyengia");

                entity.HasIndex(e => e.Email, "chuyengia_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.LinhvucId, "chuyengia_linhvuc_id_index");

                entity.HasIndex(e => e.UserId, "chuyengia_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(255)
                    .HasColumnName("cccd");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(255)
                    .HasColumnName("diachi")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.ImgMatsau)
                    .HasMaxLength(255)
                    .HasColumnName("img_matsau");

                entity.Property(e => e.ImgMattruoc)
                    .HasMaxLength(255)
                    .HasColumnName("img_mattruoc");

                entity.Property(e => e.LinhvucId)
                    .HasMaxLength(5)
                    .HasColumnName("linhvuc_id");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("sdt")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tenchuyengia)
                    .HasMaxLength(255)
                    .HasColumnName("tenchuyengia");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Linhvuc)
                    .WithMany(p => p.Chuyengia)
                    .HasForeignKey(d => d.LinhvucId)
                    .HasConstraintName("chuyengia_linhvuc_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Chuyengia)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("chuyengia_user_id_foreign");
            });

            modelBuilder.Entity<ChuyengiaDanhgia>(entity =>
            {
                entity.ToTable("chuyengia_danhgia");

                entity.HasIndex(e => e.ChuyengiaId, "chuyengia_danhgia_chuyengia_id_index");

                entity.HasIndex(e => e.KhaosatId, "chuyengia_danhgia_khaosat_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ChuyengiaId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("chuyengia_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhgia).HasColumnName("danhgia");

                entity.Property(e => e.Dexuat)
                    .HasColumnName("dexuat")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.KhaosatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("khaosat_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Chuyengia)
                    .WithMany(p => p.ChuyengiaDanhgia)
                    .HasForeignKey(d => d.ChuyengiaId)
                    .HasConstraintName("chuyengia_danhgia_chuyengia_id_foreign");

                entity.HasOne(d => d.Khaosat)
                    .WithMany(p => p.ChuyengiaDanhgia)
                    .HasForeignKey(d => d.KhaosatId)
                    .HasConstraintName("chuyengia_danhgia_khaosat_id_foreign");
            });

            modelBuilder.Entity<Danhgiaphieu1>(entity =>
            {
                entity.ToTable("danhgiaphieu1");

                entity.HasIndex(e => e.Danhsachphieu1Id, "danhgiaphieu1_danhsachphieu1_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhsachphieu1Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("danhsachphieu1_id");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.Tendanhgia)
                    .HasMaxLength(255)
                    .HasColumnName("tendanhgia")
                    .HasDefaultValueSql("'''TỔNG HỢP THÔNG TIN CHỈ SỐ ĐÁNH GIÁ MỨC ĐỘ CHUYỂN ĐỔI SỐ CỦA DOANH NGHIỆP'''");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Danhsachphieu1)
                    .WithMany(p => p.Danhgiaphieu1)
                    .HasForeignKey(d => d.Danhsachphieu1Id)
                    .HasConstraintName("danhgiaphieu1_danhsachphieu1_id_foreign");
            });

            modelBuilder.Entity<Danhgiaphieu2>(entity =>
            {
                entity.ToTable("danhgiaphieu2");

                entity.HasIndex(e => e.Danhsachphieu2Id, "danhgiaphieu2_danhsachphieu2_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhsachphieu2Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("danhsachphieu2_id");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.Tendanhgia)
                    .HasMaxLength(255)
                    .HasColumnName("tendanhgia")
                    .HasDefaultValueSql("'''CHUYỂN ĐỔI SỐ CỦA DOANH NGHIỆP NHỎ VÀ VỪA'''");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Danhsachphieu2)
                    .WithMany(p => p.Danhgiaphieu2)
                    .HasForeignKey(d => d.Danhsachphieu2Id)
                    .HasConstraintName("danhgiaphieu2_danhsachphieu2_id_foreign");
            });

            modelBuilder.Entity<Danhgiaphieu3>(entity =>
            {
                entity.ToTable("danhgiaphieu3");

                entity.HasIndex(e => e.Danhsachphieu3Id, "danhgiaphieu3_danhsachphieu3_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhsachphieu3Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("danhsachphieu3_id");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.Tendanhgia)
                    .HasMaxLength(255)
                    .HasColumnName("tendanhgia")
                    .HasDefaultValueSql("'''RÀO CẢN CHUYỂN ĐỔI SỐ TRONG DOANH NGHIỆP NHỎ VÀ VỪA'''");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Danhsachphieu3)
                    .WithMany(p => p.Danhgiaphieu3)
                    .HasForeignKey(d => d.Danhsachphieu3Id)
                    .HasConstraintName("danhgiaphieu3_danhsachphieu3_id_foreign");
            });

            modelBuilder.Entity<Danhgiaphieu4>(entity =>
            {
                entity.ToTable("danhgiaphieu4");

                entity.HasIndex(e => e.Danhsachphieu4Id, "danhgiaphieu4_danhsachphieu4_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhsachphieu4Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("danhsachphieu4_id");

                entity.Property(e => e.Noidungdexuat)
                    .HasMaxLength(255)
                    .HasColumnName("noidungdexuat")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Noidungnhucau)
                    .HasMaxLength(255)
                    .HasColumnName("noidungnhucau")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tendanhgia)
                    .HasMaxLength(255)
                    .HasColumnName("tendanhgia")
                    .HasDefaultValueSql("'''RÀO CẢN CHUYỂN ĐỔI SỐ TRONG DOANH NGHIỆP NHỎ VÀ VỪA'''");

                entity.Property(e => e.Trangthai)
                    .HasColumnType("int(11)")
                    .HasColumnName("trangthai");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Danhsachphieu4)
                    .WithMany(p => p.Danhgiaphieu4)
                    .HasForeignKey(d => d.Danhsachphieu4Id)
                    .HasConstraintName("danhgiaphieu4_danhsachphieu4_id_foreign");
            });

            modelBuilder.Entity<Danhsachphieu1>(entity =>
            {
                entity.ToTable("danhsachphieu1");

                entity.HasIndex(e => e.KhaosatId, "danhsachphieu1_khaosat_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.KhaosatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("khaosat_id");

                entity.Property(e => e.Soluonghoanthanh)
                    .HasColumnType("int(11)")
                    .HasColumnName("soluonghoanthanh");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Khaosat)
                    .WithMany(p => p.Danhsachphieu1)
                    .HasForeignKey(d => d.KhaosatId)
                    .HasConstraintName("danhsachphieu1_khaosat_id_foreign");
            });

            modelBuilder.Entity<Danhsachphieu2>(entity =>
            {
                entity.ToTable("danhsachphieu2");

                entity.HasIndex(e => e.KhaosatId, "danhsachphieu2_khaosat_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.KhaosatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("khaosat_id");

                entity.Property(e => e.Soluonghoanthanh)
                    .HasColumnType("int(11)")
                    .HasColumnName("soluonghoanthanh");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Khaosat)
                    .WithMany(p => p.Danhsachphieu2)
                    .HasForeignKey(d => d.KhaosatId)
                    .HasConstraintName("danhsachphieu2_khaosat_id_foreign");
            });

            modelBuilder.Entity<Danhsachphieu3>(entity =>
            {
                entity.ToTable("danhsachphieu3");

                entity.HasIndex(e => e.KhaosatId, "danhsachphieu3_khaosat_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.KhaosatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("khaosat_id");

                entity.Property(e => e.Soluonghoanthanh)
                    .HasColumnType("int(11)")
                    .HasColumnName("soluonghoanthanh");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Khaosat)
                    .WithMany(p => p.Danhsachphieu3)
                    .HasForeignKey(d => d.KhaosatId)
                    .HasConstraintName("danhsachphieu3_khaosat_id_foreign");
            });

            modelBuilder.Entity<Danhsachphieu4>(entity =>
            {
                entity.ToTable("danhsachphieu4");

                entity.HasIndex(e => e.KhaosatId, "danhsachphieu4_khaosat_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.KhaosatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("khaosat_id");

                entity.Property(e => e.Soluonghoanthanh)
                    .HasColumnType("int(11)")
                    .HasColumnName("soluonghoanthanh");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Khaosat)
                    .WithMany(p => p.Danhsachphieu4)
                    .HasForeignKey(d => d.KhaosatId)
                    .HasConstraintName("danhsachphieu4_khaosat_id_foreign");
            });

            modelBuilder.Entity<Denghiphieu3>(entity =>
            {
                entity.ToTable("denghiphieu3");

                entity.HasIndex(e => e.Danhsachphieu3Id, "denghiphieu3_danhsachphieu3_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhsachphieu3Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("danhsachphieu3_id");

                entity.Property(e => e.Noidung)
                    .HasColumnName("noidung")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Danhsachphieu3)
                    .WithMany(p => p.Denghiphieu3)
                    .HasForeignKey(d => d.Danhsachphieu3Id)
                    .HasConstraintName("denghiphieu3_danhsachphieu3_id_foreign");
            });

            modelBuilder.Entity<Doanhnghiep>(entity =>
            {
                entity.ToTable("doanhnghiep");

                entity.HasIndex(e => e.DoanhnghiepLoaihinhId, "doanhnghiep_doanhnghiep_loaihinh_id_index");

                entity.HasIndex(e => e.UserId, "doanhnghiep_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(255)
                    .HasColumnName("diachi")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoanhnghiepLoaihinhId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("doanhnghiep_loaihinh_id");

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .HasColumnName("fax")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Mathue)
                    .HasMaxLength(255)
                    .HasColumnName("mathue")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ngaylap)
                    .HasColumnType("date")
                    .HasColumnName("ngaylap");

                entity.Property(e => e.Soluongnhansu)
                    .HasColumnType("int(11)")
                    .HasColumnName("soluongnhansu");

                entity.Property(e => e.Tentienganh).HasColumnName("tentienganh");

                entity.Property(e => e.Tentiengviet).HasColumnName("tentiengviet");

                entity.Property(e => e.Tenviettat)
                    .HasMaxLength(255)
                    .HasColumnName("tenviettat")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.DoanhnghiepLoaihinh)
                    .WithMany(p => p.Doanhnghiep)
                    .HasForeignKey(d => d.DoanhnghiepLoaihinhId)
                    .HasConstraintName("doanhnghiep_doanhnghiep_loaihinh_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Doanhnghiep)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("doanhnghiep_user_id_foreign");
            });

            modelBuilder.Entity<DoanhnghiepDaidien>(entity =>
            {
                entity.ToTable("doanhnghiep_daidien");

                entity.HasIndex(e => e.DoanhnghiepId, "doanhnghiep_daidien_doanhnghiep_id_index");

                entity.HasIndex(e => e.Email, "doanhnghiep_daidien_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(255)
                    .HasColumnName("cccd");

                entity.Property(e => e.Chucvu)
                    .HasMaxLength(255)
                    .HasColumnName("chucvu")
                    .HasDefaultValueSql("'''Quản lý'''");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(255)
                    .HasColumnName("diachi")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoanhnghiepId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("doanhnghiep_id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.ImgMatsau)
                    .HasMaxLength(255)
                    .HasColumnName("img_matsau");

                entity.Property(e => e.ImgMattruoc)
                    .HasMaxLength(255)
                    .HasColumnName("img_mattruoc");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("sdt")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tendaidien)
                    .HasMaxLength(255)
                    .HasColumnName("tendaidien");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Doanhnghiep)
                    .WithMany(p => p.DoanhnghiepDaidien)
                    .HasForeignKey(d => d.DoanhnghiepId)
                    .HasConstraintName("doanhnghiep_daidien_doanhnghiep_id_foreign");
            });

            modelBuilder.Entity<DoanhnghiepLoaihinh>(entity =>
            {
                entity.ToTable("doanhnghiep_loaihinh");

                entity.HasIndex(e => e.LinhvucId, "doanhnghiep_loaihinh_linhvuc_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(255)
                    .HasColumnName("hinhanh")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LinhvucId)
                    .HasMaxLength(5)
                    .HasColumnName("linhvuc_id");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tenloaihinh)
                    .HasMaxLength(255)
                    .HasColumnName("tenloaihinh");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Linhvuc)
                    .WithMany(p => p.DoanhnghiepLoaihinh)
                    .HasForeignKey(d => d.LinhvucId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("doanhnghiep_loaihinh_linhvuc_id_foreign");
            });

            modelBuilder.Entity<DoanhnghiepSdt>(entity =>
            {
                entity.ToTable("doanhnghiep_sdt");

                entity.HasIndex(e => e.DoanhnghiepId, "doanhnghiep_sdt_doanhnghiep_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoanhnghiepId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("doanhnghiep_id");

                entity.Property(e => e.Loaisdt)
                    .HasMaxLength(255)
                    .HasColumnName("loaisdt")
                    .HasDefaultValueSql("'''ban'''");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("sdt");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Doanhnghiep)
                    .WithMany(p => p.DoanhnghiepSdt)
                    .HasForeignKey(d => d.DoanhnghiepId)
                    .HasConstraintName("doanhnghiep_sdt_doanhnghiep_id_foreign");
            });

            modelBuilder.Entity<Hiephoidoanhnghiep>(entity =>
            {
                entity.ToTable("hiephoidoanhnghiep");

                entity.HasIndex(e => e.UserId, "hiephoidoanhnghiep_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(255)
                    .HasColumnName("diachi")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("sdt");

                entity.Property(e => e.Tentienganh).HasColumnName("tentienganh");

                entity.Property(e => e.Tentiengviet).HasColumnName("tentiengviet");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Hiephoidoanhnghiep)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("hiephoidoanhnghiep_user_id_foreign");
            });

            modelBuilder.Entity<HiephoidoanhnghiepDaidien>(entity =>
            {
                entity.ToTable("hiephoidoanhnghiep_daidien");

                entity.HasIndex(e => e.Email, "hiephoidoanhnghiep_daidien_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.HiephoidoanhnghiepId, "hiephoidoanhnghiep_daidien_hiephoidoanhnghiep_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.HiephoidoanhnghiepId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("hiephoidoanhnghiep_id");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("sdt")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tendaidien)
                    .HasMaxLength(255)
                    .HasColumnName("tendaidien");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Hiephoidoanhnghiep)
                    .WithMany(p => p.HiephoidoanhnghiepDaidien)
                    .HasForeignKey(d => d.HiephoidoanhnghiepId)
                    .HasConstraintName("hiephoidoanhnghiep_daidien_hiephoidoanhnghiep_id_foreign");
            });

            modelBuilder.Entity<Khaosat>(entity =>
            {
                entity.ToTable("khaosat");

                entity.HasIndex(e => e.DoanhnghiepId, "doanhnghiep_khaosat_id_foreign_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoanhnghiepId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("doanhnghiep_id");

                entity.Property(e => e.Thoigiantao)
                    .HasColumnType("date")
                    .HasColumnName("thoigiantao");

                entity.Property(e => e.Tongdiem)
                    .HasColumnType("int(11)")
                    .HasColumnName("tongdiem");

                entity.Property(e => e.Trangthai)
                    .HasColumnType("int(11)")
                    .HasColumnName("trangthai");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Doanhnghiep)
                    .WithMany(p => p.Khaosat)
                    .HasForeignKey(d => d.DoanhnghiepId)
                    .HasConstraintName("doanhnghiep_khaosat_id_foreign");
            });

            modelBuilder.Entity<KhaosatChienluoc>(entity =>
            {
                entity.ToTable("khaosat_chienluoc");

                entity.HasIndex(e => e.KhaosatId, "khaosat_chienluoc_khaosat_id_index");

                entity.HasIndex(e => e.MohinhId, "khaosat_chienluoc_mohinh_id_index");

                entity.HasIndex(e => e.MucdoId, "khaosat_chienluoc_mucdo_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.KhaosatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("khaosat_id");

                entity.Property(e => e.MohinhId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mohinh_id");

                entity.Property(e => e.MucdoId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mucdo_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Khaosat)
                    .WithMany(p => p.KhaosatChienluoc)
                    .HasForeignKey(d => d.KhaosatId)
                    .HasConstraintName("khaosat_chienluoc_khaosat_id_foreign");

                entity.HasOne(d => d.Mohinh)
                    .WithMany(p => p.KhaosatChienluoc)
                    .HasForeignKey(d => d.MohinhId)
                    .HasConstraintName("khaosat_chienluoc_mohinh_id_foreign");

                entity.HasOne(d => d.Mucdo)
                    .WithMany(p => p.KhaosatChienluoc)
                    .HasForeignKey(d => d.MucdoId)
                    .HasConstraintName("khaosat_chienluoc_mucdo_id_foreign");
            });

            modelBuilder.Entity<Linhvuc>(entity =>
            {
                entity.ToTable("linhvuc");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(255)
                    .HasColumnName("hinhanh")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tenlinhvuc)
                    .HasMaxLength(255)
                    .HasColumnName("tenlinhvuc");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Mohinh>(entity =>
            {
                entity.ToTable("mohinh");

                entity.HasIndex(e => e.DoanhnghiepLoaihinhId, "mohinh_doanhnghiep_loaihinh_id_index");

                entity.HasIndex(e => e.MohinhTrucotId, "mohinh_mohinh_trucot_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoanhnghiepLoaihinhId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("doanhnghiep_loaihinh_id");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(255)
                    .HasColumnName("hinhanh")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MohinhTrucotId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mohinh_trucot_id");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tenmohinh)
                    .HasMaxLength(255)
                    .HasColumnName("tenmohinh");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DoanhnghiepLoaihinh)
                    .WithMany(p => p.Mohinh)
                    .HasForeignKey(d => d.DoanhnghiepLoaihinhId)
                    .HasConstraintName("mohinh_doanhnghiep_loaihinh_id_foreign");

                entity.HasOne(d => d.MohinhTrucot)
                    .WithMany(p => p.Mohinh)
                    .HasForeignKey(d => d.MohinhTrucotId)
                    .HasConstraintName("mohinh_mohinh_trucot_id_foreign");
            });

            modelBuilder.Entity<MohinhLotrinh>(entity =>
            {
                entity.ToTable("mohinh_lotrinh");

                entity.HasIndex(e => e.MohinhId, "mohinh_lotrinh_mohinh_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Luuy)
                    .HasMaxLength(255)
                    .HasColumnName("luuy")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MohinhId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("mohinh_id");

                entity.Property(e => e.Nhansu)
                    .HasColumnType("int(11)")
                    .HasColumnName("nhansu");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Taichinh)
                    .HasColumnType("int(11)")
                    .HasColumnName("taichinh");

                entity.Property(e => e.Tenlotrinh)
                    .HasMaxLength(255)
                    .HasColumnName("tenlotrinh");

                entity.Property(e => e.Thoigian)
                    .HasColumnType("date")
                    .HasColumnName("thoigian");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Mohinh)
                    .WithMany(p => p.MohinhLotrinh)
                    .HasForeignKey(d => d.MohinhId)
                    .HasConstraintName("mohinh_lotrinh_mohinh_id_foreign");
            });

            modelBuilder.Entity<MohinhTrucot>(entity =>
            {
                entity.ToTable("mohinh_trucot");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(255)
                    .HasColumnName("ghichu")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(255)
                    .HasColumnName("hinhanh")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tentrucot)
                    .HasMaxLength(255)
                    .HasColumnName("tentrucot");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Mucdo>(entity =>
            {
                entity.ToTable("mucdo");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tenmucdo)
                    .HasMaxLength(255)
                    .HasColumnName("tenmucdo");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.ToTable("tintuc");

                entity.HasIndex(e => e.LinhvucId, "tintuc_linhvuc_id_index");

                entity.HasIndex(e => e.UserId, "tintuc_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Duyet)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("duyet");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(255)
                    .HasColumnName("hinhanh")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LinhvucId)
                    .HasMaxLength(5)
                    .HasColumnName("linhvuc_id");

                entity.Property(e => e.Luotxem)
                    .HasColumnType("int(11)")
                    .HasColumnName("luotxem");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tieude)
                    .HasMaxLength(255)
                    .HasColumnName("tieude");

                entity.Property(e => e.Tomtat).HasColumnName("tomtat");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Linhvuc)
                    .WithMany(p => p.Tintuc)
                    .HasForeignKey(d => d.LinhvucId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("tintuc_linhvuc_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tintuc)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("tintuc_user_id_foreign");
            });

            modelBuilder.Entity<Traloiphieu1>(entity =>
            {
                entity.ToTable("traloiphieu1");

                entity.HasIndex(e => e.Cauhoiphieu1Id, "traloiphieu1_cauhoiphieu1_id_index");

                entity.HasIndex(e => e.Danhgiaphieu1Id, "traloiphieu1_danhgiaphieu1_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cauhoiphieu1Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("cauhoiphieu1_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhgiaphieu1Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("danhgiaphieu1_id");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.Trangthai)
                    .HasColumnType("int(11)")
                    .HasColumnName("trangthai");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Cauhoiphieu1)
                    .WithMany(p => p.Traloiphieu1)
                    .HasForeignKey(d => d.Cauhoiphieu1Id)
                    .HasConstraintName("traloiphieu1_cauhoiphieu1_id_foreign");

                entity.HasOne(d => d.Danhgiaphieu1)
                    .WithMany(p => p.Traloiphieu1)
                    .HasForeignKey(d => d.Danhgiaphieu1Id)
                    .HasConstraintName("traloiphieu1_danhgiaphieu1_id_foreign");
            });

            modelBuilder.Entity<Traloiphieu2>(entity =>
            {
                entity.ToTable("traloiphieu2");

                entity.HasIndex(e => e.Cauhoiphieu2Id, "traloiphieu2_cauhoiphieu2_id_index");

                entity.HasIndex(e => e.Danhgiaphieu2Id, "traloiphieu2_danhgiaphieu2_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cauhoiphieu2Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("cauhoiphieu2_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhgiaphieu2Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("danhgiaphieu2_id");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.Trangthai)
                    .HasColumnType("int(11)")
                    .HasColumnName("trangthai");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Cauhoiphieu2)
                    .WithMany(p => p.Traloiphieu2)
                    .HasForeignKey(d => d.Cauhoiphieu2Id)
                    .HasConstraintName("traloiphieu2_cauhoiphieu2_id_foreign");

                entity.HasOne(d => d.Danhgiaphieu2)
                    .WithMany(p => p.Traloiphieu2)
                    .HasForeignKey(d => d.Danhgiaphieu2Id)
                    .HasConstraintName("traloiphieu2_danhgiaphieu2_id_foreign");
            });

            modelBuilder.Entity<Traloiphieu3>(entity =>
            {
                entity.ToTable("traloiphieu3");

                entity.HasIndex(e => e.Cauhoiphieu3Id, "traloiphieu3_cauhoiphieu3_id_index");

                entity.HasIndex(e => e.Danhgiaphieu3Id, "traloiphieu3_danhgiaphieu3_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cauhoiphieu3Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("cauhoiphieu3_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Danhgiaphieu3Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("danhgiaphieu3_id");

                entity.Property(e => e.Diem)
                    .HasColumnType("int(11)")
                    .HasColumnName("diem");

                entity.Property(e => e.Trangthai)
                    .HasColumnType("int(11)")
                    .HasColumnName("trangthai");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Cauhoiphieu3)
                    .WithMany(p => p.Traloiphieu3)
                    .HasForeignKey(d => d.Cauhoiphieu3Id)
                    .HasConstraintName("traloiphieu3_cauhoiphieu3_id_foreign");

                entity.HasOne(d => d.Danhgiaphieu3)
                    .WithMany(p => p.Traloiphieu3)
                    .HasForeignKey(d => d.Danhgiaphieu3Id)
                    .HasConstraintName("traloiphieu3_danhgiaphieu3_id_foreign");
            });

            modelBuilder.Entity<UserVaitro>(entity =>
            {
                entity.ToTable("user_vaitro");

                entity.HasIndex(e => e.UserId, "user_vaitro_user_id_index");

                entity.HasIndex(e => e.VaitroId, "user_vaitro_vaitro_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.VaitroId)
                    .HasMaxLength(5)
                    .HasColumnName("vaitro_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserVaitro)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_vaitro_user_id_foreign");

                entity.HasOne(d => d.Vaitro)
                    .WithMany(p => p.UserVaitro)
                    .HasForeignKey(d => d.VaitroId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("user_vaitro_vaitro_id_foreign");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("email_verified_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .HasColumnName("remember_token")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'''Inactive'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Vaitro>(entity =>
            {
                entity.ToTable("vaitro");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(255)
                    .HasColumnName("hinhanh")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tenvaitro)
                    .HasMaxLength(100)
                    .HasColumnName("tenvaitro");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
