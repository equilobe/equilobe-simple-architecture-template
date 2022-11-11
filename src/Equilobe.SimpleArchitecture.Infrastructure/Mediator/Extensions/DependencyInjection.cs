using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Equilobe.SimpleArchitecture.Infrastructure.Mediator.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
