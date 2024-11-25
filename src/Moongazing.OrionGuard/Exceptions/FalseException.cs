namespace Moongazing.OrionGuard.Exceptions;

public class FalseException : GuardException
{
    public FalseException(string parameterName)
        : base($"{parameterName} cannot be false.") { }
}
