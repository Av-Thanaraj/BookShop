using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.BaseDbContext
{
    public partial class BookShopDbContext : DbContext
    {
        public BookShopDbContext()
        {
        }

        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<BookGenre> BookGenres { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Author).HasMaxLength(100);
                entity.Property(e => e.CoverImagePath).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(100);
                entity.Property(e => e.Genre).HasMaxLength(100);
                entity.Property(e => e.Isbn)
                    .HasMaxLength(100)
                    .HasColumnName("ISBN");
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PublishedDate).HasColumnType("datetime");
                entity.Property(e => e.Publisher).HasMaxLength(100);
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasOne(d => d.Book).WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BookGenres_Books");

                entity.HasOne(d => d.Genre).WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_BookGenres_Genres");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(200);
                entity.Property(e => e.Country).HasMaxLength(200);
                entity.Property(e => e.FullName).HasMaxLength(200);
                entity.Property(e => e.PhoneNumber).HasMaxLength(200);
                entity.Property(e => e.PostalCode).HasMaxLength(200);

                entity.HasOne(d => d.User).WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Customers_Users");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreName).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.PaymentMethod).HasMaxLength(50);
                entity.Property(e => e.ShippingAddress).HasMaxLength(500);
                entity.Property(e => e.Status).HasMaxLength(50);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TrackingNumber).HasMaxLength(500);

                entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Book).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_OrderItems_Books");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderItems_Orders");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
                entity.Property(e => e.PaymentMethod).HasMaxLength(100);
                entity.Property(e => e.PaymentStatus).HasMaxLength(100);

                entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Payments_Orders");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.LastLogin).HasMaxLength(100);
                entity.Property(e => e.PasswordHash).HasMaxLength(1000);
                entity.Property(e => e.Role).HasMaxLength(100);
                entity.Property(e => e.Username).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
