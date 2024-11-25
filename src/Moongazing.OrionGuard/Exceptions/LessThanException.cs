namespace Moongazing.OrionGuard.Exceptions;

public class LessThanException : GuardException
{
    public LessThanException(string parameterName)
        : base($"{parameterName} must be at least the minimum value.") { }
}
