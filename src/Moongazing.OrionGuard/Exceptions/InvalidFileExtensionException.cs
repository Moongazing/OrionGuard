namespace Moongazing.OrionGuard.Exceptions;

public class InvalidFileExtensionException : GuardException
{
    public InvalidFileExtensionException(string parameterName)
        : base($"{parameterName} is not a valid file extension.") { }
}
