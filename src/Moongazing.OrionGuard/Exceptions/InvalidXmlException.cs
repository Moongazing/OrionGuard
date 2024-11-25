namespace Moongazing.OrionGuard.Exceptions;

public class InvalidXmlException : GuardException
{
    public InvalidXmlException(string parameterName)
        : base($"{parameterName} is not a valid XML.") { }
}
