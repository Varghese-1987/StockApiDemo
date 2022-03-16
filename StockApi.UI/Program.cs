using Serilog;
using StockApi.UI.Installers;

IConfiguration configuration= new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger=new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();


builder.Services.InstallServicesInApplication(builder.Configuration);

var app = builder.Build();
app.ConfigureApplicationBuilder();

