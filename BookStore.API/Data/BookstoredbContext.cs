using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookstoredbContext : IdentityDbContext<ApiUser>
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
        base.OnModelCreating(modelBuilder);
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

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "26edbb25-0042-46bf-9192-b37fbc78561c"
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = "fa826e82-b733-4b92-9a45-fb30f3cbc166"
            }
        );

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                Id = "fffd1919-af93-452c-adb6-efd6e36e41a7",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApiUser
            {
                Id = "20e74a0b-06d1-48e2-b2e7-860719dab25b",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "26edbb25-0042-46bf-9192-b37fbc78561c",
                UserId = "20e74a0b-06d1-48e2-b2e7-860719dab25b"
            },
            new IdentityUserRole<string>
            {
                RoleId = "fa826e82-b733-4b92-9a45-fb30f3cbc166",
                UserId = "fffd1919-af93-452c-adb6-efd6e36e41a7"
            });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
