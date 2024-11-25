namespace Moongazing.OrionGuard.Exceptions;

public class UnrealisticBirthDateException : GuardException
{
    public UnrealisticBirthDateException(string parameterName)
        : base($"{parameterName} is unrealistic.") { }
}
