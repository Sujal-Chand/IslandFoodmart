using IslandFoodmart.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using MySqlConnector;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace IslandFoodmart
{
    public class Program

    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //Use for macOS
            builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            /*Use for Windows
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(connectionString)); */
            //Also Check appsettings.json to change DefaultConnection Path
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<DatabaseUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();
            builder.Services.AddHealthChecks();
            builder.Services.AddRazorPages();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Employee", "Customer" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DatabaseUser>>();

                string Aemail = "admin@islandfoodmart.com";
                string Apassword = "Admin123,";

                string Eemail = "employee@islandfoodmart.com";
                string Epassword = "Employee123,";

                if (await userManager.FindByEmailAsync(Aemail) == null)
                {
                    var user = new DatabaseUser();
                    user.UserName = Aemail;
                    user.Email = Aemail;
                    user.FirstName = "Admin";
                    user.LastName = "Account";
                    
                    await userManager.CreateAsync(user, Apassword);
                    await userManager.AddToRoleAsync(user, "Admin");

                }
                if (await userManager.FindByEmailAsync(Eemail) == null)
                {
                    var user = new DatabaseUser();
                    user.UserName = Eemail;
                    user.Email = Eemail;
                    user.FirstName = "Employee";
                    user.LastName = "Account";

                    await userManager.CreateAsync(user, Epassword);
                    await userManager.AddToRoleAsync(user, "Employee");
                    
                }
            }

            app.Run();
        }

    }
}