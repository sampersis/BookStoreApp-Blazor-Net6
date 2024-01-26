using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookstoredbContext : DbContext
{
    public BookstoredbContext()
    {
    }

    public BookstoredbContext(DbContextOptions<BookstoredbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authour> Authours { get; set; }

    public virtual DbSet<Book> Books { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=BLUE\\DOTNET;Database=bookstoredb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authour__3214EC07C9DDE6F1");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC072CEBA56B");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA9C9CFB5E").IsUnique();

            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Auth).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthId)
                .HasConstraintName("FK_Books_Authours");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
