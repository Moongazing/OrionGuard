namespace Moongazing.OrionGuard.Exceptions;

public class FileNotExistsException : GuardException
{
    public FileNotExistsException(string parameterName)
        : base($"{parameterName} does not exist.") { }
}
