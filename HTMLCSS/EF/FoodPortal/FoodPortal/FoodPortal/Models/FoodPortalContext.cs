using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Models;

public partial class FoodPortalContext : DbContext
{
    public FoodPortalContext()
    {
    }

    public FoodPortalContext(DbContextOptions<FoodPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddOnsDetail> AddOnsDetails { get; set; }

    public virtual DbSet<AddOnsMaster> AddOnsMasters { get; set; }

    public virtual DbSet<AdditionalCategoryMaster> AdditionalCategoryMasters { get; set; }

    public virtual DbSet<AdditionalProduct> AdditionalProducts { get; set; }

    public virtual DbSet<AdditionalProductsDetail> AdditionalProductsDetails { get; set; }

    public virtual DbSet<AllergyDetail> AllergyDetails { get; set; }

    public virtual DbSet<AllergyMaster> AllergyMasters { get; set; }

    public virtual DbSet<DeliveryOption> DeliveryOptions { get; set; }

    public virtual DbSet<FoodTypeCount> FoodTypeCounts { get; set; }

    public virtual DbSet<GroupSize> GroupSizes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PlateSize> PlateSizes { get; set; }

    public virtual DbSet<StdFoodCategoryMaster> StdFoodCategoryMasters { get; set; }

    public virtual DbSet<StdFoodOrderDetail> StdFoodOrderDetails { get; set; }

    public virtual DbSet<StdProduct> StdProducts { get; set; }

    public virtual DbSet<TimeSlot> TimeSlots { get; set; }

    public virtual DbSet<TrackStatus> TrackStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog = FoodPortal2;integrated security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddOnsDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AddOnsDe__3214EC073CB75243");

            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.OrderId).HasMaxLength(10);

            entity.HasOne(d => d.AddOns).WithMany(p => p.AddOnsDetails)
                .HasForeignKey(d => d.AddOnsId)
                .HasConstraintName("FK_AddOnsDetails_AddOnsMaster");

            entity.HasOne(d => d.Order).WithMany(p => p.AddOnsDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_AddOnsDetails_Orders");
        });

        modelBuilder.Entity<AddOnsMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AddOnsMa__3214EC079FAEDD41");

            entity.ToTable("AddOnsMaster");

            entity.Property(e => e.AddOnsImage).HasMaxLength(1);
            entity.Property(e => e.AddOnsName).HasMaxLength(30);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<AdditionalCategoryMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addition__3214EC0717DDD611");

            entity.ToTable("AdditionalCategoryMaster");

            entity.Property(e => e.AdditionalCategory).HasMaxLength(30);
        });

        modelBuilder.Entity<AdditionalProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addition__3214EC0743171428");

            entity.Property(e => e.AdditionalProductsImages).HasMaxLength(1);
            entity.Property(e => e.AdditionalProductsName).HasMaxLength(30);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.AdditionalCategory).WithMany(p => p.AdditionalProducts)
                .HasForeignKey(d => d.AdditionalCategoryId)
                .HasConstraintName("FK_AdditionalProducts_AdditionalCategoryMaster");
        });

        modelBuilder.Entity<AdditionalProductsDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addition__3214EC07A453B9B1");

            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.OrderId).HasMaxLength(10);

            entity.HasOne(d => d.AdditionalProducts).WithMany(p => p.AdditionalProductsDetails)
                .HasForeignKey(d => d.AdditionalProductsId)
                .HasConstraintName("FK_AdditionalProductsDetails_AdditionalProducts");

            entity.HasOne(d => d.Order).WithMany(p => p.AdditionalProductsDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_AdditionalProductsDetails_Orders");
        });

        modelBuilder.Entity<AllergyDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AllergyD__3214EC076CB28D73");

            entity.Property(e => e.OrdersId).HasMaxLength(10);

            entity.HasOne(d => d.Allergy).WithMany(p => p.AllergyDetails)
                .HasForeignKey(d => d.AllergyId)
                .HasConstraintName("FK_AllergyDetail_AllergyMaster");

            entity.HasOne(d => d.Orders).WithMany(p => p.AllergyDetails)
                .HasForeignKey(d => d.OrdersId)
                .HasConstraintName("FK_AllergyDetails_Orders");
        });

        modelBuilder.Entity<AllergyMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AllergyM__3213E83FAE627C23");

            entity.ToTable("AllergyMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllergyName).HasMaxLength(200);
        });

        modelBuilder.Entity<DeliveryOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC072CD005F6");

            entity.ToTable("DeliveryOption");

            entity.Property(e => e.DeliveryOption1)
                .HasMaxLength(30)
                .HasColumnName("DeliveryOption");
        });

        modelBuilder.Entity<FoodTypeCount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FoodType__3214EC07765E8BED");

            entity.ToTable("FoodTypeCount");

            entity.Property(e => e.OrderId).HasMaxLength(10);

            entity.HasOne(d => d.Order).WithMany(p => p.FoodTypeCounts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_FoodTypeCount_Orders");

            entity.HasOne(d => d.PlateSize).WithMany(p => p.FoodTypeCounts)
                .HasForeignKey(d => d.PlateSizeId)
                .HasConstraintName("FK_FoodTypeCount_PlateSize");
        });

        modelBuilder.Entity<GroupSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupSiz__3214EC0787D08841");

            entity.ToTable("GroupSize");

            entity.Property(e => e.GroupType).HasMaxLength(20);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0716BEFEFF");

            entity.Property(e => e.Id).HasMaxLength(10);
            entity.Property(e => e.AdditionalAllergy).HasMaxLength(200);
            entity.Property(e => e.AdditionalNote).HasMaxLength(1000);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.DeliveryOption).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryOptionId)
                .HasConstraintName("FK_Orders_DeliveryOption");

            entity.HasOne(d => d.GroupSize).WithMany(p => p.Orders)
                .HasForeignKey(d => d.GroupSizeId)
                .HasConstraintName("FK_Orders_GroupSize");

            entity.HasOne(d => d.PlateSize).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PlateSizeId)
                .HasConstraintName("FK_Orders_PlateSize");

            entity.HasOne(d => d.TimeSlot).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TimeSlotId)
                .HasConstraintName("FK_Orders_TimeSlots");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<PlateSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlateSiz__3214EC07C5429C75");

            entity.ToTable("PlateSize");

            entity.Property(e => e.Menu)
                .HasMaxLength(200)
                .HasColumnName("menu");
            entity.Property(e => e.NonvegPlateCost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PlateType).HasMaxLength(20);
            entity.Property(e => e.VegPlateCost).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<StdFoodCategoryMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StdFoodC__3214EC07DA0DC6A6");

            entity.ToTable("StdFoodCategoryMaster");

            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StdFoodOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StdFoodO__3214EC07E5749CBE");

            entity.Property(e => e.OrderId).HasMaxLength(10);

            entity.HasOne(d => d.Order).WithMany(p => p.StdFoodOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_StdFoodOrderDetails_Orders");

            entity.HasOne(d => d.Products).WithMany(p => p.StdFoodOrderDetails)
                .HasForeignKey(d => d.ProductsId)
                .HasConstraintName("FK_StdFoodOrderDetails_StdProducts");
        });

        modelBuilder.Entity<StdProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StdProdu__3214EC07140F0D53");

            entity.Property(e => e.FoodProductImage).HasMaxLength(1);
            entity.Property(e => e.ProductsName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Categories).WithMany(p => p.StdProducts)
                .HasForeignKey(d => d.CategoriesId)
                .HasConstraintName("FK_StdProducts_Orders");
        });

        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TimeSlot__3214EC0797509880");

            entity.Property(e => e.AddTimeSlot).HasMaxLength(25);
        });

        modelBuilder.Entity<TrackStatus>(entity =>
        {
            entity.ToTable("TrackStatus");

            entity.Property(e => e.Id).HasMaxLength(10);
            entity.Property(e => e.OrderId).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Order).WithMany(p => p.TrackStatuses)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_TrackStatus_Orders");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__Users__C9F284577F9613D8");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.EmailId).HasMaxLength(32);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.Role).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
