#pragma warning disable

public static class CorsService
{
    /// <summary>
    /// Configs Cors
    /// </summary>
    /// <param name="services"></param>
    public static void AddCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("_myAllowSpecificOrigins", policy =>
            {
                policy.AllowAnyHeader()
                      .AllowAnyMethod()
                      .SetIsOriginAllowed(origin => true)
                      .AllowCredentials();
            });
        });
    }

    /// <summary>
    /// UseCors
    /// </summary>
    /// <param name="app"></param>
    public static void UseCors(this IApplicationBuilder app)
    {
        app.UseCors("_myAllowSpecificOrigins");
    }
}
