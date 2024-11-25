namespace Moongazing.OrionGuard.Exceptions;

public class EmptyFileException : GuardException
{
    public EmptyFileException(string parameterName)
        : base($"{parameterName} cannot be empty.") { }
}
