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
                new Category { CategoryID = 5, CategoryName = "Personal Care" });
           /*builder.Entity<Product>().HasData(
                new Product { ProductID = 1, CategoryID = 3, ImagePath = "image", ProductName = "V Drink 250ml", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 2, CategoryID = 3, ImagePath = "image", ProductName = "Coke 440ml", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 3, CategoryID = 3, ImagePath = "image", ProductName = "Sprite", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 4, CategoryID = 3, ImagePath = "image", ProductName = "Red Bull", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 5, CategoryID = 3, ImagePath = "image", ProductName = "Lift", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 6, CategoryID = 3, ImagePath = "image", ProductName = "Big Ben Mince & Cheese ", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 7, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 8, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 9, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 10, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 11, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 12, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 13, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 14, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 15, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 16, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 17, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 18, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 19, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 },
                new Product { ProductID = 20, CategoryID = 3, ImagePath = "image", ProductName = "V Drink", ProductPrice = 4, ProductStock = 20 }); */
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