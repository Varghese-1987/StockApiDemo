using Microsoft.OpenApi.Models;

namespace StockApi.UI.Installers
{
    public static class MvcInstaller 
    {
        public static void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Test Swagger API",
                    Version = "v1"
                }
                );
            });
        }
    }
}
