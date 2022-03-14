using StockApi.UI.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServicesInApplication(builder.Configuration);

var app = builder.Build();

app.ConfigureApplicationBuilder();

