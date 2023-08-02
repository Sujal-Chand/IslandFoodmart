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