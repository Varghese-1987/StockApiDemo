﻿using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using StockApi.UI.Filters;
using System.Reflection;

namespace StockApi.UI.Installers
{
    public static class MvcInstaller
    {
        public static void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews((options) =>
            {
                options.Filters.Add<ApiModelValidationFilter>();
            }).
                AddFluentValidation(config =>
                {
                    config.DisableDataAnnotationsValidation = false;
                    config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

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
