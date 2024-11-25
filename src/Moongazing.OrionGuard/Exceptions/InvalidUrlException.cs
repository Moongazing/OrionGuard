namespace Moongazing.OrionGuard.Exceptions;

public class InvalidUrlException : GuardException
{
    public InvalidUrlException(string parameterName)
        : base($"{parameterName} is not a valid URL.") { }
}
