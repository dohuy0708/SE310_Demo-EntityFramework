using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_DBFirst.Models;

public partial class QlsinhVienContext : DbContext
{
    public QlsinhVienContext()
    {
    }

    public QlsinhVienContext(DbContextOptions<QlsinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-JRRAO9EA\\DOHUY;Initial Catalog=QLSinhVien;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Mssv).HasName("PK__SinhVien__6CB3B7F946AC3873");

            entity.ToTable("SinhVien");

            entity.Property(e => e.Mssv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MSSV");
            entity.Property(e => e.Khoa).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
