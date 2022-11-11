using Equilobe.Microservice.Core.ExceptionHandling.Extensions;
using Equilobe.Microservice.Core.Logging.Extensions;
using Equilobe.SimpleArchitecture.Startup.Extensions;
using Equilobe.Microservice.Core.Swagger;
using Equilobe.SimpleArchitecture.Common.Cors.Extensions;
using Equilobe.Microservice.Core.AspNet.Mvc.Version.Extensions;
using System.Reflection;
using Equilobe.Microservice.Core.Swagger.Settings;
using Equilobe.SimpleArchitecture.Common.Settings.Extensions;
using Equilobe.SimpleArchitecture.Common.Cors;
using Equilobe.SimpleArchitecture.Infrastructure.Mediator.Extensions;
using FluentValidation;

var (builder, services, configuration) = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var assembly = Assembly.GetExecutingAssembly();

services.AddLogging();
services.AddCors(configuration);
services.AddHttpContextAccessor();
services.AddExceptionHandlers(true);
services.AddExceptionHandlersFrom(assembly);
services.AddMediator(assembly);
services.AddValidatorsFromAssembly(assembly);
services.AddApplicationSettings(configuration);
services.AddSwagger((SwaggerSettings x) =>
{
    configuration.GetSection("ApplicationSettings:SwaggerSettings").Bind(x);
    x.CustomEndpoints = new[] { CustomEndpoint.Health, CustomEndpoint.Version };
});
services.AddAuthorization();
services.AddControllers();
services.AddHealthChecks();

var (middleware, endpoints, app)
    = builder.Build();

middleware.UseExceptionHandling();
middleware.UseExceptionLogging();
middleware.UseCors(PolicyNames.AllowOrigin);
middleware.UseHttpsRedirection();
middleware.UseRouting();
middleware.UseAuthentication();
middleware.UseAuthorization();
middleware.UseSwagger();


endpoints.MapControllers();
endpoints.MapHealthChecks("/api/health");
endpoints.UseVersionEndpoint("/api/version", "version.txt");

app.Run();

