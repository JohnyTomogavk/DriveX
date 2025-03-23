namespace DriveX.Domain.Exceptions.Users;

public class UserRegistrationException : Exception
{
    public UserRegistrationException(string message) : base(message)
    {
    }
}
