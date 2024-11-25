namespace Moongazing.OrionGuard.Exceptions;

public class WeakPasswordException : GuardException
{
    public WeakPasswordException(string parameterName)
        : base($"{parameterName} is too weak.") { }
}
