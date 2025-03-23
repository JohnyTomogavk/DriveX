using Microsoft.AspNetCore.Identity;

namespace DriveX.Infrastructure.Config;

public class AppIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DuplicateEmail(string email)
    {
        return new IdentityError
        {
            Code = nameof(DuplicateEmail),
            Description = "Пользователь с такой почтой уже существует"
        };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
        return new IdentityError
        {
            Code = nameof(DuplicateUserName),
            Description = "Пользователь с таким логином уже существует"
        };
    }
}
