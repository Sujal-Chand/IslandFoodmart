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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
        public DbSet<IslandFoodmart.Models.Category>? Category { get; set; }
        public DbSet<IslandFoodmart.Models.Payment>? Payment { get; set; }
        public DbSet<IslandFoodmart.Models.Product>? Product { get; set; }
        public DbSet<IslandFoodmart.Models.ShoppingItem>? ShoppingCart { get; set; }
        public DbSet<IslandFoodmart.Models.ShoppingOrder>? ShoppingOrder { get; set; }
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<DatabaseUser>
    {
        public void Configure(EntityTypeBuilder<DatabaseUser> builder) 
        {
            builder.Property(u => u.FirstName).HasMaxLength(20);
        }
    }
}