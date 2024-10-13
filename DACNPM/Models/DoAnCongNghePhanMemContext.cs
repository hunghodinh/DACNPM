using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DACNPM.Models;

public partial class DoAnCongNghePhanMemContext : DbContext
{
    public DoAnCongNghePhanMemContext()
    {
    }

    public DoAnCongNghePhanMemContext(DbContextOptions<DoAnCongNghePhanMemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbDichVu> TbDichVus { get; set; }

    public virtual DbSet<TbHoaDon> TbHoaDons { get; set; }

    public virtual DbSet<TbHopDong> TbHopDongs { get; set; }

    public virtual DbSet<TbNhanVien> TbNhanViens { get; set; }

    public virtual DbSet<TbPhong> TbPhongs { get; set; }

    public virtual DbSet<TbSinhVien> TbSinhViens { get; set; }

    public virtual DbSet<TbTaiKhoan> TbTaiKhoans { get; set; }

    public virtual DbSet<TbThanhVienPhong> TbThanhVienPhongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source= LAPTOP-V7VL83QP; initial catalog=DoAnCongNghePhanMem; integrated security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbDichVu>(entity =>
        {
            entity.HasKey(e => e.IdDichVu);

            entity.ToTable("TbDichVu");

            entity.Property(e => e.IdDichVu).ValueGeneratedNever();
            entity.Property(e => e.DonGia).HasColumnType("money");
            entity.Property(e => e.TenDichVu).HasMaxLength(50);
        });

        modelBuilder.Entity<TbHoaDon>(entity =>
        {
            entity.HasKey(e => e.IdHoaDon);

            entity.ToTable("TbHoaDon");

            entity.Property(e => e.GhiChu).HasColumnType("text");
            entity.Property(e => e.NgayDong).HasColumnType("datetime");
            entity.Property(e => e.NguoiDong).HasMaxLength(50);
            entity.Property(e => e.TienPhong).HasColumnType("money");
            entity.Property(e => e.TongTien).HasColumnType("money");

            entity.HasOne(d => d.IdDichVuNavigation).WithMany(p => p.TbHoaDons)
                .HasForeignKey(d => d.IdDichVu)
                .HasConstraintName("FK_TbHoaDon_TbDichVu");

            entity.HasOne(d => d.IdHopDongNavigation).WithMany(p => p.TbHoaDons)
                .HasForeignKey(d => d.IdHopDong)
                .HasConstraintName("FK_TbHoaDon_TbHopDong");
        });

        modelBuilder.Entity<TbHopDong>(entity =>
        {
            entity.HasKey(e => e.IdHopDong);

            entity.ToTable("TbHopDong");

            entity.Property(e => e.ChuY).HasColumnType("text");
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.TienCoc).HasColumnType("money");

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.IdNhanVien)
                .HasConstraintName("FK_TbHopDong_TbNhanVien");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.IdPhong)
                .HasConstraintName("FK_TbHopDong_TbPhong");

            entity.HasOne(d => d.IdSinhVienNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.IdSinhVien)
                .HasConstraintName("FK_TbHopDong_TbSinhVien");
        });

        modelBuilder.Entity<TbNhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNhanVien);

            entity.ToTable("TbNhanVien");

            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.SoDt)
                .HasMaxLength(50)
                .HasColumnName("SoDT");
            entity.Property(e => e.TenNhanVien).HasMaxLength(50);
        });

        modelBuilder.Entity<TbPhong>(entity =>
        {
            entity.HasKey(e => e.IdPhong);

            entity.ToTable("TbPhong");

            entity.Property(e => e.DonGia).HasColumnType("money");
            entity.Property(e => e.LoaiPhong).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.TenPhong).HasMaxLength(50);
        });

        modelBuilder.Entity<TbSinhVien>(entity =>
        {
            entity.HasKey(e => e.IdSinhVien);

            entity.ToTable("TbSinhVien");

            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.SoDt)
                .HasMaxLength(10)
                .HasColumnName("SoDT");
            entity.Property(e => e.TenSinhVien).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdTaiKhoan);

            entity.ToTable("TbTaiKhoan");

            entity.Property(e => e.MatKhau).HasMaxLength(200);
            entity.Property(e => e.TenTk)
                .HasMaxLength(50)
                .HasColumnName("TenTK");

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.TbTaiKhoans)
                .HasForeignKey(d => d.IdNhanVien)
                .HasConstraintName("FK_TbTaiKhoan_TbNhanVien");
        });

        modelBuilder.Entity<TbThanhVienPhong>(entity =>
        {
            entity.ToTable("TbThanhVienPhong");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.TbThanhVienPhongs)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbThanhVienPhong_TbPhong");

            entity.HasOne(d => d.IdSinhVienNavigation).WithMany(p => p.TbThanhVienPhongs)
                .HasForeignKey(d => d.IdSinhVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbThanhVienPhong_TbSinhVien");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
