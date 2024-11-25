namespace Moongazing.OrionGuard.Exceptions;

public class InvalidGuidException : GuardException
{
    public InvalidGuidException(string parameterName)
        : base($"{parameterName} is not a valid GUID.") { }
}
