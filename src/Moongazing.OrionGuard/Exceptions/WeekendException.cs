namespace Moongazing.OrionGuard.Exceptions;

public class WeekendException : GuardException
{
    public WeekendException(string parameterName)
        : base($"{parameterName} cannot be a weekend.") { }
}
