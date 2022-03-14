using StockApi.Persistance.Context;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace StockApi.Persistance
{
    public static class CoreDbInitializer
    {
        public static void Initialize(IServiceCollection serviceDescriptors)
        {

            var serviceProvider = serviceDescriptors.BuildServiceProvider();
            using (CoreDbContext coreContext = (CoreDbContext)serviceProvider.GetService(typeof(CoreDbContext)))
            {
                coreContext.Database.Migrate();

            }
        }
    }
}
