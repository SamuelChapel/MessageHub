using FastEndpoints;
using MessageHub.Api.Common;

namespace MessageHub.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddFastEndpoints();

        services.AddScoped<MapperlyMapper>();

        return services;
    }
}
