namespace Moongazing.OrionGuard.Exceptions;

public class TrueException : GuardException
{
    public TrueException(string parameterName)
        : base($"{parameterName} cannot be true.") { }
}
