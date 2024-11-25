namespace Moongazing.OrionGuard.Exceptions;

public class SpecifyDayException : GuardException
{
    public SpecifyDayException(string parameterName, DayOfWeek day)
        : base($"{parameterName} cannot be {day}.") { }
}
