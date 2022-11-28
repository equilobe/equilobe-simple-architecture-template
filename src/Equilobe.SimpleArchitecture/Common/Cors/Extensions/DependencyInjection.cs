namespace Equilobe.SimpleArchitecture.Common.Cors.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: PolicyNames.AllowOrigin,
                policy =>
                {
                    policy.WithOrigins(configuration["ApplicationSettings:CorsAllow"] ?? default!)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                }
            );
        });

        return services;
    }
}
