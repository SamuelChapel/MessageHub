using FastEndpoints;
using MessageHub.Api.Common;
using MessageHub.Api.Contracts.Users;
using MessageHub.Application.Users.Commands.CreateUser;
using MessageHub.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace MessageHub.Api.EndPoints.Users;

public class CreateUser(
    [FromServices] MapperlyMapper mapper,
    [FromServices] Application.Common.ICommandHandler<CreateUserCommand, User> handler) : Endpoint<CreateUserRequest, UserResponse>
{
    private readonly MapperlyMapper _mapper = mapper;
    private readonly Application.Common.ICommandHandler<CreateUserCommand, User> _handler = handler;

    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var query = _mapper.Map(req);

        var response = _mapper.Map(await _handler.Handle(query));

        await SendOkAsync(response, ct);
    }
}

