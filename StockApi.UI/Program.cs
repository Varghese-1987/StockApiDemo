using Serilog;
using StockApi.UI.Installers;


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
app.ConfigureApplicationBuilder();

