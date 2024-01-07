using MessageHub.Api.Contracts.Users;
using MessageHub.Application.Users.Commands.CreateUser;
using MessageHub.Domain.Users;
using Riok.Mapperly.Abstractions;

namespace MessageHub.Api.Common;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class MapperlyMapper
{
    public partial CreateUserCommand Map(CreateUserRequest createUserRequest);

    [MapProperty($"{nameof(User.Id)}.{nameof(User.Id.Value)}", nameof(UserResponse.Id))]
    public partial UserResponse Map(User createUserRequest);
}
