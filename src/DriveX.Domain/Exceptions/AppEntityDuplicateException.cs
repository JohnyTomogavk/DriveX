namespace DriveX.Domain.Exceptions;

public class AppEntityDuplicateException : Exception
{
    public AppEntityDuplicateException(string message) : base(message)
    {
    }
}
