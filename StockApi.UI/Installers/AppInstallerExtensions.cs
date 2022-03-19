using Microsoft.EntityFrameworkCore;
using Serilog;
using StockApi.Persistance.Context;

namespace StockApi.UI.Installers
{
    public static class AppInstallerExtensions
    {
        public static void ConfigureApplicationBuilder( this WebApplication applicationBuilder)
        {
           

            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseSerilogRequestLogging(configuration =>
            {
                configuration.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.000}ms";
            });

            var swaggerOptions = new SwaggerConfig.SwaggerConfig();
            applicationBuilder.Configuration.GetSection(nameof(SwaggerConfig)).Bind(swaggerOptions);
            applicationBuilder.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });
            applicationBuilder.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndPoint, swaggerOptions.Description);
            });

            applicationBuilder.UseRouting();

            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();

            applicationBuilder.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            applicationBuilder.MapRazorPages();

            using (var scope = applicationBuilder.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<CoreDbContext>();
                dataContext.Database.Migrate();
            }

            applicationBuilder.Run();


        }
    }
}
