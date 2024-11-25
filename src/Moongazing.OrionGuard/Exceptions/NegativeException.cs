namespace Moongazing.OrionGuard.Exceptions;

public class NegativeException : GuardException
{
    public NegativeException(string parameterName)
        : base($"{parameterName} cannot be negative.") { }
}
