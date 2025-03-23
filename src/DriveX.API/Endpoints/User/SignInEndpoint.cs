using System.Net;
using DriveX.API.Dto;
using FastEndpoints;
using MediatR;

namespace DriveX.API.Endpoints.User;

public class SignInEndpoint : Endpoint<SignUpUserDto>
{
    private readonly IMediator _mediator;

    public SignInEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/user/sign-up");
        AllowAnonymous();
        Description(
            description => description
                .WithDescription("Creates new user")
                .ClearDefaultProduces()
                .Produces(201)
                .Produces(400)
                .Produces(409)
                .Produces(500));
    }

    public override async Task HandleAsync(SignUpUserDto req, CancellationToken ct)
    {
        var commandRequest = req.ToRequestCommandDto();
        await _mediator.Send(commandRequest, ct);
        await SendAsync(null, StatusCodes.Status201Created, ct);
    }
}
