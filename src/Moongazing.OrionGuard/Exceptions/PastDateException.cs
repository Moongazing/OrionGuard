namespace Moongazing.OrionGuard.Exceptions;

public class PastDateException : GuardException
{
    public PastDateException(string parameterName)
        : base($"{parameterName} cannot be in the past.") { }
}
