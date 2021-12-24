using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions
        <AppDbContext> options) : base(options)
        {
           
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopProduct> ShopProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>()
                        .Property(et => et.Id)
                        .ValueGeneratedNever();

            modelBuilder.Entity<Product>()
                        .Property(et => et.Id)
                        .ValueGeneratedNever();

            modelBuilder.Entity<ShopProduct>().HasKey(t => new { t.ShopId, t.ProductId });

            modelBuilder.Entity<ShopProduct>()
                        .HasOne(t => t.Shop)
                        .WithMany(t => t.ShopProducts)
                        .HasForeignKey(t => t.ShopId);


            modelBuilder.Entity<ShopProduct>()
                        .HasOne(t => t.Product)
                        .WithMany(t => t.ShopProducts)
                        .HasForeignKey(t => t.ProductId);

            var shops = new[]
            {
                new Shop{Id=1, Name="Виталюр", WorkTime="Круглосуточно"},
                new Shop{Id=2, Name="Зарина", WorkTime="Круглосуточно"}
            };

            var products = new[]
            {
                new Product{ Id=1, Name="Молоко", Description="Жирное"},
                new Product{ Id=2, Name="Молоко", Description="Полу жирное"},
                new Product{ Id=3, Name="Молоко", Description="Сухое"},
                new Product{ Id=4, Name="Хлеб", Description="Нарезной"},
                new Product{ Id=5, Name="Хлеб", Description="Цельный"}  
            };

            var shopProducts = new[]
            {
             new ShopProduct{ShopId=1, ProductId=1},
             new ShopProduct{ShopId=1, ProductId=2},
             new ShopProduct{ShopId=1, ProductId=4},
             new ShopProduct{ShopId=2, ProductId=3},
             new ShopProduct{ShopId=2, ProductId=5}
            };

            modelBuilder.Entity<Shop>().HasData(shops[0],
                shops[1]);

            modelBuilder.Entity<Product>().HasData(products[0],
                products[1],
                products[2],
                products[3],
                products[4]);

            modelBuilder.Entity<ShopProduct>().HasData(shopProducts[0], 
                shopProducts[1],
                shopProducts[2],
                shopProducts[3],
                shopProducts[4]);

        }
    }
}
