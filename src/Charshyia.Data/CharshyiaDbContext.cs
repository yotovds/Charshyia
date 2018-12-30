using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charshyia.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Charshyia.Data
{
    public class CharshyiaDbContext : IdentityDbContext<CharshyiaUser>
    {
        public CharshyiaDbContext(DbContextOptions<CharshyiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Shop> Shops { get; set; }

        //public DbSet<ShopProduct> ShopProduct { get; set; }

        public DbSet<ProductComment> ProductComments { get; set; }

        public DbSet<ShopComment> ShopComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShopProduct>()
                .HasKey(sp => new { sp.ProductId, sp.ShopId });
            builder.Entity<ShopProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.Shops)
                .HasForeignKey(sp => sp.ProductId);
            builder.Entity<ShopProduct>()
                .HasOne(sp => sp.Shop)
                .WithMany(s => s.Products)
                .HasForeignKey(sp => sp.ShopId);

            builder.Entity<ShopUser>()
                .HasKey(su => new { su.ProducerId, su.ShopId });
            builder.Entity<ShopUser>()
                .HasOne(su => su.Producer)
                .WithMany(u => u.Shops)
                .HasForeignKey(su => su.ProducerId);
            builder.Entity<ShopUser>()
                .HasOne(su => su.Shop)
                .WithMany(s => s.Producers)
                .HasForeignKey(su => su.ShopId);

            builder.Entity<Product>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Product);

            builder.Entity<Shop>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Shop);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
