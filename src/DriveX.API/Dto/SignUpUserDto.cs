using DriveX.Application.Commands.User;

namespace DriveX.API.Dto;

public record SignUpUserDto
{
    public string FIO { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
    public string ConfirmedPassword { get; init; }
    public string Email { get; init; }
    public string? PhoneNumber { get; init; }

    public SignUpUserRequest ToRequestCommandDto()
    {
        return new SignUpUserRequest
        {
            FIO = FIO,
            UserName = UserName,
            Password = Password,
            Email = Email,
            PhoneNumber = PhoneNumber,
            ConfirmedPassword = ConfirmedPassword,
        };
    }
}
