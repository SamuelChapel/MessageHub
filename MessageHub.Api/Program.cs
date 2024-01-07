using FastEndpoints;
using MessageHub.Api.Extensions;
using MessageHub.Application.Extensions;
using MessageHub.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApi()
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    //app.UseAuthorization();

    app.UseFastEndpoints();

    app.Run();
}