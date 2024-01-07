using MessageHub.Infrastructure.Persistence.Context;
using MessageHub.Infrastructure.Persistence.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace MessageHub.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<MessageHubDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
