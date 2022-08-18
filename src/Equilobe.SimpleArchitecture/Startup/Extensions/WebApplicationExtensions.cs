namespace Equilobe.SimpleArchitecture.Startup.Extensions;

public static class WebApplicationExtensions
{
    public static void Deconstruct(
        this WebApplication application, 
        out IApplicationBuilder middleware, 
        out IEndpointRouteBuilder endpoints, 
        out WebApplication app)
    {
        middleware = application;
        endpoints = application;
        app = application;
    }
}