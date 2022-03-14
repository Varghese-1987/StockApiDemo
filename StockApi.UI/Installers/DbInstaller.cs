using StockApi.DataAccess.Services;
using StockApi.Persistance.Context;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StockApi.UI.Installers
{
    public static class DbInstaller 
    {
        public static void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CoreDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IStockService, StockService>();
        }
    }
}
