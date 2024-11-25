namespace Moongazing.OrionGuard.Exceptions;

public class InvalidIpException : GuardException
{
    public InvalidIpException(string parameterName)
        : base($"{parameterName} is not a valid IP address.") { }
}
