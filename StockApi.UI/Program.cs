using Serilog;
using StockApi.UI.Extensions;
using StockApi.UI.Installers;

Log.Logger = new LoggerConfiguration()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext();
  
});


builder.Services.InstallServicesInApplication(builder.Configuration);

var app = builder.Build();
app.ConfigureApplicationBuilder(Log.Logger);

