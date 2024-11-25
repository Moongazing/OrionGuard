namespace Moongazing.OrionGuard.Exceptions;

public class GreaterThanException : GuardException
{
    public GreaterThanException(string parameterName)
        : base($"{parameterName} must be at most the maximum value.") { }
}
