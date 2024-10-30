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

        public virtual DbSet<BookShop.Domain.Entities.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(200);
                entity.Property(e => e.Country).HasMaxLength(200);
                entity.Property(e => e.FullName).HasMaxLength(200);
                entity.Property(e => e.PhoneNumber).HasMaxLength(200);
                entity.Property(e => e.PostalCode).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
