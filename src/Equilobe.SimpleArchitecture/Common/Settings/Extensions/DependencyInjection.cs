
namespace Equilobe.SimpleArchitecture.Common.Settings.Extensions;

public static class DependencyInjection
{
    public static void AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var appSettings = configuration.GetSection("ApplicationSettings");

        services.Configure<ApplicationSettings>(appSettings);
    }
}
