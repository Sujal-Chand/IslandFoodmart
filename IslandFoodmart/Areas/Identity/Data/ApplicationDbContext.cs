using IslandFoodmart.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IslandFoodmart.Models;

namespace IslandFoodmart.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<DatabaseUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IslandFoodmart.Models.Category>? Category { get; set; }
        public DbSet<IslandFoodmart.Models.Payment>? Payment { get; set; }
        public DbSet<IslandFoodmart.Models.Product>? Product { get; set; }
        public DbSet<IslandFoodmart.Models.ShoppingItem>? ShoppingItem { get; set; }
        public DbSet<IslandFoodmart.Models.ShoppingOrder>? ShoppingOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             builder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Fresh Foods" },
                new Category { CategoryID = 2, CategoryName = "Frozen Foods" },
                new Category { CategoryID = 3, CategoryName = "Drinks" },
                new Category { CategoryID = 4, CategoryName = "Pantry" },
                new Category { CategoryID = 5, CategoryName = "Personal Care" },
                new Category { CategoryID = 6, CategoryName = "Dairy" });
              builder.Entity<Product>().HasData(
                 new Product { ProductID = 1, CategoryID = 6, ImagePath = "foodimage_0000_Layer-30.png", ProductName = "Ben & Jerry's Chocolate Chip Cookie Dough", ProductPrice = 12.99M, ProductStock = 9, SpecialPrice = 0 },
                 new Product { ProductID = 2, CategoryID = 6, ImagePath = "foodimage_0001_Layer-29.png", ProductName = "Tip Top Creamy Vanilla 2L", ProductPrice = 6.20M, ProductStock = 7, SpecialPrice = 0 },
                 new Product { ProductID = 3, CategoryID = 5, ImagePath = "foodimage_0002_Layer-28.png", ProductName = "Band-Aid", ProductPrice = 4, ProductStock = 20, SpecialPrice = 0 },
                 new Product { ProductID = 4, CategoryID = 5, ImagePath = "foodimage_0003_Layer-27.png", ProductName = "Panadol Paracetamol 500mg", ProductPrice = 11.99M, ProductStock = 20, SpecialPrice = 0 },
                 new Product { ProductID = 5, CategoryID = 5, ImagePath = "foodimage_0004_Layer-26.png", ProductName = "Colgate Triple Action 110g", ProductPrice = 4.5M, ProductStock = 12, SpecialPrice = 4M },
                 new Product { ProductID = 6, CategoryID = 4, ImagePath = "foodimage_0005_Layer-25.png", ProductName = "Maggi Chicken Moodles 360g", ProductPrice = 5, ProductStock = 10, SpecialPrice = 4.5M },
                 new Product { ProductID = 7, CategoryID = 4, ImagePath = "foodimage_0006_Layer-24.png", ProductName = "Indomie Instant Noodles 85g", ProductPrice = 5.99M, ProductStock = 11, SpecialPrice = 0 },
                 new Product { ProductID = 8, CategoryID = 4, ImagePath = "foodimage_0007_Layer-23.png", ProductName = "Pacific Corned Beef 340g", ProductPrice = 9.99M, ProductStock = 15, SpecialPrice = 0 },
                 new Product { ProductID = 9, CategoryID = 4, ImagePath = "foodimage_0008_Layer-22.png", ProductName = "Palm Corned Beef 326g", ProductPrice = 10.99M, ProductStock = 9, SpecialPrice = 0 },
                 new Product { ProductID = 10, CategoryID = 2, ImagePath = "foodimage_0009_Layer-21.png", ProductName = "Tegal Whole Chicken 2.3kg", ProductPrice = 15.60M, ProductStock = 12, SpecialPrice = 0 },
                 new Product { ProductID = 11, CategoryID = 2, ImagePath = "foodimage_0010_Layer-20.png", ProductName = "New Zealand Peas 1kg", ProductPrice = 5.5M, ProductStock = 10, SpecialPrice = 0 },
                 new Product { ProductID = 12, CategoryID = 6, ImagePath = "foodimage_0011_Layer-19.png", ProductName = "UHF Standard Milk 1L", ProductPrice = 3.5M, ProductStock = 10, SpecialPrice = 0 },
                 new Product { ProductID = 13, CategoryID = 4, ImagePath = "foodimage_0012_Layer-18.png", ProductName = "Shapes Cheese & Bacon 180g", ProductPrice = 4, ProductStock = 18, SpecialPrice = 0 },
                 new Product { ProductID = 14, CategoryID = 5, ImagePath = "foodimage_0013_Layer-17.png", ProductName = "Toilet Paper 3ply", ProductPrice = 18, ProductStock = 6, SpecialPrice = 16.99M },
                 new Product { ProductID = 15, CategoryID = 5, ImagePath = "foodimage_0014_Layer-16.png", ProductName = "Toilet Paper 2ply", ProductPrice = 14.99M, ProductStock = 7, SpecialPrice = 0 },
                 new Product { ProductID = 16, CategoryID = 4, ImagePath = "foodimage_0015_Layer-15.png", ProductName = "Griffins Cookie Bear H&T", ProductPrice = 3, ProductStock = 6, SpecialPrice = 0 },
                 new Product { ProductID = 17, CategoryID = 1, ImagePath = "foodimage_0016_Layer-14.png", ProductName = "Farmer Brown Dozen Eggs", ProductPrice = 12, ProductStock = 4, SpecialPrice = 0 },
                 new Product { ProductID = 18, CategoryID = 1, ImagePath = "foodimage_0017_Layer-13.png", ProductName = "Tip Top White Toast Bread", ProductPrice = 5, ProductStock = 8, SpecialPrice = 0 },
                 new Product { ProductID = 19, CategoryID = 1, ImagePath = "foodimage_0018_Layer-12.png", ProductName = "Natures Fresh White Toast Bread", ProductPrice = 6, ProductStock = 8, SpecialPrice = 5.5M },
                 new Product { ProductID = 20, CategoryID = 5, ImagePath = "foodimage_0019_Layer-11.png", ProductName = "Nivea Protect & Moisture Sunscreen 50+SPF", ProductPrice = 18.99M, ProductStock = 5, SpecialPrice = 16.99M },
                 new Product { ProductID = 21, CategoryID = 3, ImagePath = "foodimage_0020_Layer-10.png", ProductName = "Coke Classic 2L", ProductPrice = 5.5M, ProductStock = 20, SpecialPrice = 0 },
                 new Product { ProductID = 22, CategoryID = 3, ImagePath = "foodimage_0021_Layer-9.png", ProductName = "Sprite Natural Flavour 2L", ProductPrice = 5.5M, ProductStock = 20, SpecialPrice = 0 },
                 new Product { ProductID = 23, CategoryID = 3, ImagePath = "foodimage_0022_Layer-8.png", ProductName = "Coke Classic 440ml", ProductPrice = 3.99M, ProductStock = 41, SpecialPrice = 2.99M },
                 new Product { ProductID = 24, CategoryID = 3, ImagePath = "foodimage_0023_Layer-7.png", ProductName = "V Drink Green 500ml", ProductPrice = 5.5M, ProductStock = 30, SpecialPrice = 4.5M },
                 new Product { ProductID = 25, CategoryID = 3, ImagePath = "foodimage_0024_Layer-6.png", ProductName = "V Drink Greem 250ml", ProductPrice = 3.2M, ProductStock = 50, SpecialPrice = 0 },
                 new Product { ProductID = 26, CategoryID = 3, ImagePath = "foodimage_0025_Layer-5.png", ProductName = "V Drink Blue 500ml", ProductPrice = 5.5M, ProductStock = 42, SpecialPrice = 4.5M },
                 new Product { ProductID = 27, CategoryID = 6, ImagePath = "foodimage_0026_Layer-4.png", ProductName = "Meadow Fresh Original Milk 2L", ProductPrice = 6.5M, ProductStock = 8, SpecialPrice = 0 },
                 new Product { ProductID = 28, CategoryID = 4, ImagePath = "foodimage_0027_Layer-3.png", ProductName = "Anchor Blue Milk Powder 1kg", ProductPrice = 3.5M, ProductStock = 7, SpecialPrice = 0 },
                 new Product { ProductID = 29, CategoryID = 6, ImagePath = "foodimage_0028_Layer-2.png", ProductName = "Anchor Blue Milk 3L", ProductPrice = 7, ProductStock = 20, SpecialPrice = 0 },
                 new Product { ProductID = 30, CategoryID = 6, ImagePath = "foodimage_0029_Layer-1.png", ProductName = "Anchor Blue Milk 2L", ProductPrice = 5.5M, ProductStock = 20, SpecialPrice = 0 }
                 );
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
      
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<DatabaseUser>
    {
        public void Configure(EntityTypeBuilder<DatabaseUser> builder) 
        {
            builder.Property(u => u.FirstName).HasMaxLength(20);
            builder.Property(u => u.LastName).HasMaxLength(20);
        }
    }
}