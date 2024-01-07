using MessageHub.Application.Common;
using MessageHub.Application.Users.Commands.CreateUser;
using MessageHub.Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace MessageHub.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateUserCommand, User>, CreateUserCommandHandler>();

        return services;
    }
}
