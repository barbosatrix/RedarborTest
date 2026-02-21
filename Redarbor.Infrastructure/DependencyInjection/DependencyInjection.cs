using Microsoft.Extensions.DependencyInjection;

namespace Redarbor.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Aquí luego registraremos:
        // DbContext
        // Repositorios
        // Dapper
        // etc.

        return services;
    }
}
