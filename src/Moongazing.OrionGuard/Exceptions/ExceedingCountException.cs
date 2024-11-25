namespace Moongazing.OrionGuard.Exceptions;

public class ExceedingCountException : GuardException
{
    public ExceedingCountException(string parameterName, int count)
       : base($"{parameterName} cannot exceed {count}.") { }
}
