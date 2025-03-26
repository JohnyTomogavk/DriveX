using DriveX.API.Dto;
using DriveX.API.Dto.Requests;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DriveX.API.Endpoints.User;

public class SignUpEndpoint : Endpoint<SignUpUserRequestDto>
{
    private readonly IMediator _mediator;

    public SignUpEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/users/sign-up");
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

    public override async Task HandleAsync(SignUpUserRequestDto req, CancellationToken ct)
    {
        var commandRequest = req.ToRequestCommandDto();
        await _mediator.Send(commandRequest, ct);
        await SendAsync(null, StatusCodes.Status201Created, ct);
    }
}
