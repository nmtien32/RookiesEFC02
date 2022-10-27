using Microsoft.EntityFrameworkCore;
using RookiesEFC02.Models;

namespace RookiesEFC02.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .ToTable("Category")
            .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                        .Property(c => c.Id)
                        .HasColumnName("CategoryId")
                        .HasColumnType("int")
                        .UseIdentityColumn(1)//
                        .IsRequired();

            modelBuilder.Entity<Category>()
                        .Property(c => c.CategoryName)
                        .HasColumnName("CategoryName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                        .ToTable("Product")
                        .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                        .HasOne<Category>(p => p.Category)
                        .WithMany(p => p.Products)
                        .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                       .Property(p => p.Id)
                       .HasColumnName("ProductId")
                       .HasColumnType("int")
                       .UseIdentityColumn(1)//
                       .IsRequired();

            modelBuilder.Entity<Product>()
                        .Property(p => p.ProductName)
                        .HasColumnName("ProductName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                        .Property(p => p.Manufacturer)
                        .HasColumnName("ProductManufacturer")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                        .Property(p => p.CategoryId)
                        .HasColumnName("ProductCategoryId")
                        .HasColumnType("int")
                        .IsRequired();

            modelBuilder.Entity<Category>()
                        .HasData(new Category
                        {
                            Id = 1,
                            CategoryName = "Laptop"
                        });
            modelBuilder.Entity<Product>()
                        .HasData(new Product
                        {
                            Id = 1,
                            CategoryId = 1,
                            ProductName = "Dell Inspiron",
                            Manufacturer = "Viet Nam"
                        });
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}