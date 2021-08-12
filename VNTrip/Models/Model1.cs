namespace VNTrip.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AnhLoaiPhongK> AnhLoaiPhongKS { get; set; }
        public virtual DbSet<AnhLoaiPhongNN> AnhLoaiPhongNNs { get; set; }
        public virtual DbSet<Bill_Detail> Bill_Detail { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<KhachSan> KhachSans { get; set; }
        public virtual DbSet<Khuvuc> Khuvucs { get; set; }
        public virtual DbSet<LoaiPhongK> LoaiPhongKS { get; set; }
        public virtual DbSet<LoaiPhongNN> LoaiPhongNNs { get; set; }
        public virtual DbSet<New_Image> New_Image { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NhaNghi> NhaNghis { get; set; }
        public virtual DbSet<VeMayBay> VeMayBays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.Bill_Detail)
                .WithOptional(e => e.Bill)
                .HasForeignKey(e => e.ID_Bill);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.ID_Customer);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.ID_Customer);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.LoaiPhongKS)
                .WithOptional(e => e.KhachSan)
                .HasForeignKey(e => e.ID_KhachSan);

            modelBuilder.Entity<Khuvuc>()
                .HasMany(e => e.KhachSans)
                .WithOptional(e => e.Khuvuc)
                .HasForeignKey(e => e.ID_Khuvuc);

            modelBuilder.Entity<Khuvuc>()
                .HasMany(e => e.NhaNghis)
                .WithOptional(e => e.Khuvuc)
                .HasForeignKey(e => e.ID_Khuvuc);

            modelBuilder.Entity<Khuvuc>()
                .HasMany(e => e.VeMayBays)
                .WithOptional(e => e.Khuvuc)
                .HasForeignKey(e => e.ID_Khuvuc);

            modelBuilder.Entity<LoaiPhongK>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LoaiPhongK>()
                .Property(e => e.Promotion_Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LoaiPhongK>()
                .HasMany(e => e.AnhLoaiPhongKS)
                .WithOptional(e => e.LoaiPhongK)
                .HasForeignKey(e => e.ID_LoaiPhongKS);

            modelBuilder.Entity<LoaiPhongK>()
                .HasMany(e => e.Bill_Detail)
                .WithOptional(e => e.LoaiPhongK)
                .HasForeignKey(e => e.ID_LoaiPhongKS);

            modelBuilder.Entity<LoaiPhongK>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.LoaiPhongK)
                .HasForeignKey(e => e.ID_LoaiPhongKS);

            modelBuilder.Entity<LoaiPhongNN>()
                .Property(e => e.Price2h)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LoaiPhongNN>()
                .Property(e => e.PriceNight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LoaiPhongNN>()
                .HasMany(e => e.AnhLoaiPhongNNs)
                .WithOptional(e => e.LoaiPhongNN)
                .HasForeignKey(e => e.ID_LoaiPhongNN);

            modelBuilder.Entity<LoaiPhongNN>()
                .HasMany(e => e.Bill_Detail)
                .WithOptional(e => e.LoaiPhongNN)
                .HasForeignKey(e => e.ID_LoaiPhongNN);

            modelBuilder.Entity<LoaiPhongNN>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.LoaiPhongNN)
                .HasForeignKey(e => e.ID_LoaiPhongNN);

            modelBuilder.Entity<News>()
                .HasMany(e => e.New_Image)
                .WithOptional(e => e.News)
                .HasForeignKey(e => e.ID_New);

            modelBuilder.Entity<NhaNghi>()
                .HasMany(e => e.LoaiPhongNNs)
                .WithOptional(e => e.NhaNghi)
                .HasForeignKey(e => e.ID_NhaNghi);

            modelBuilder.Entity<VeMayBay>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VeMayBay>()
                .HasMany(e => e.Bill_Detail)
                .WithOptional(e => e.VeMayBay)
                .HasForeignKey(e => e.ID_VeMayBay);

            modelBuilder.Entity<VeMayBay>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.VeMayBay)
                .HasForeignKey(e => e.ID_VeMayBay);
        }
    }
}
