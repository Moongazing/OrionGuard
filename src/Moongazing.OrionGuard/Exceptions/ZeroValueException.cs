namespace Moongazing.OrionGuard.Exceptions;

public class ZeroValueException : GuardException
{
    public ZeroValueException(string parameterName)
        : base($"{parameterName} cannot be zero.") { }
}
