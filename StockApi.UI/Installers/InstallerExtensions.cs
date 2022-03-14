namespace StockApi.UI.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInApplication(this IServiceCollection services, IConfiguration configuration)
        {
            DbInstaller.InstallServices(services, configuration);
            MvcInstaller.InstallServices(services, configuration);
        }
    }
}
