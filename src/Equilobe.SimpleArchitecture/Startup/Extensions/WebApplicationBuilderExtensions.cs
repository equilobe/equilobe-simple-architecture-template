namespace Equilobe.SimpleArchitecture.Startup.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void Deconstruct(
        this WebApplicationBuilder builder, 
        out WebApplicationBuilder b,
        out IServiceCollection services,
        out IConfiguration configuration)
    {
        b = builder;
        services = builder.Services;
        configuration = builder.Configuration;
    }
}