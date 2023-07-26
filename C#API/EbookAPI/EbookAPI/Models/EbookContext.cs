using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EbookAPI.Models;

public partial class EbookContext : DbContext
{
    internal object Input;
    internal object input;

    public EbookContext()
    {
    }

    public EbookContext(DbContextOptions<EbookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookBorrow> BookBorrows { get; set; }

    public virtual DbSet<BookBorrowMaster> BookBorrowMasters { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Subscriptiondetail> Subscriptiondetails { get; set; }

    public virtual DbSet<User> Users { get; set; }


    public virtual DbSet<Input> Inputs { get; set; }    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Books__447D36EB409B5F93");

            entity.Property(e => e.Isbn)
                .HasMaxLength(10)
                .HasColumnName("ISBN");
            entity.Property(e => e.Author).HasMaxLength(20);
            entity.Property(e => e.Language).HasMaxLength(30);
            entity.Property(e => e.Publisher).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("FK__Books__Categoryi__3B75D760");
        });

        modelBuilder.Entity<BookBorrow>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BorrowDate).HasColumnType("date");
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.Isbn)
                .HasMaxLength(10)
                .HasColumnName("ISBN");
            entity.Property(e => e.ReturnDate).HasColumnType("date");

            entity.HasOne(d => d.Borrow).WithMany()
                .HasForeignKey(d => d.Borrowid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Borrowid");

            entity.HasOne(d => d.IsbnNavigation).WithMany()
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISBN");
        });

        modelBuilder.Entity<BookBorrowMaster>(entity =>
        {
            entity.HasKey(e => e.Borrowid).HasName("PK__Book_bor__42929C97E943B972");

            entity.ToTable("Book_borrow_master");

            entity.Property(e => e.FineRupees).HasColumnName("Fine_Rupees");

            entity.HasOne(d => d.User).WithMany(p => p.BookBorrowMasters)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_Userid");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("PK__Categori__190606236DA78EE4");

            entity.Property(e => e.Categoryid).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(20);
        });

        modelBuilder.Entity<Subscriptiondetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AmountRupees).HasColumnName("Amount_Rupees");
            entity.Property(e => e.SubEnddate)
                .HasColumnType("date")
                .HasColumnName("Sub_enddate");
            entity.Property(e => e.SubStartdate)
                .HasColumnType("date")
                .HasColumnName("Sub_startdate");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_Userid1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__Users__1797D024CAA4D90A");

            entity.Property(e => e.Address).HasMaxLength(20);
            entity.Property(e => e.City).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.State1)
                .HasMaxLength(20)
                .HasColumnName("State_1");
            entity.Property(e => e.UserType).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
