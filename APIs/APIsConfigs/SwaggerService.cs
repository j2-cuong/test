#pragma warning disable

using Microsoft.OpenApi.Models;
using System.Reflection;

public static class SwaggerService
{
    /// <summary>
    /// Configs swaggers
    /// </summary>
    /// <param name="services"></param>
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "CuongNH APIs", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }

    /// <summary>
    /// môi trường swagger
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public static void UseSwaggerUI(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment() || env.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
