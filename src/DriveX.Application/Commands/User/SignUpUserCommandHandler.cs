using DriveX.Domain.Entities;
using DriveX.Domain.Exceptions;
using DriveX.Domain.Exceptions.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DriveX.Application.Commands.User;

public record SignUpUserRequest : IRequest
{
    public required string FIO { get; init; }
    public required string UserName { get; init; }
    public required string Password { get; init; }
    public required string Email { get; init; }
    public required string? PhoneNumber { get; init; }
    public required string ConfirmedPassword { get; init; }
}

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserRequest>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserStore<AppUser> _userStore;

    public SignUpUserCommandHandler(UserManager<AppUser> userManager, IUserStore<AppUser> userStore)
    {
        _userManager = userManager;
        _userStore = userStore;
    }

    public async Task Handle(SignUpUserRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
        {
            throw new AppEntityDuplicateException("Пользователь с такой почтой уже существует");
        }

        var user = new AppUser
        {
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            FIO = request.FIO,
        };

        var userCreationResult = await _userManager.CreateAsync(user, request.Password);
        if (!userCreationResult.Succeeded)
        {
            var creationErrorDetails = userCreationResult.Errors.Select(e => e.Description);
            var message = string.Join("\n", creationErrorDetails);

            throw new UserRegistrationException(message);
        }
    }
}
