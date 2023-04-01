using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Configuration;
namespace Store3.Models
{
    public partial class DbStore : DbContext
    {
        public DbStore()
            : base("name=DbStore1")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NXB> NXBs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.DonGia)
                  //.HasColumnType("decimal(18, 2)");
                  .HasColumnType("int");

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            //modelBuilder.Entity<Sach>()
            //    .Property(e => e.GiaBan)
            //    .HasPrecision(18, 0);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sach>()
                .Property(e => e.GiaBan)
                .HasColumnType("int");

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TacGia>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);
        }
    }
}
