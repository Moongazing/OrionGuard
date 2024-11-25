namespace Moongazing.OrionGuard.Exceptions;

public class OnlyAlphanumericCharacterException : GuardException
{
    public OnlyAlphanumericCharacterException(string parameterName)
        : base($"{parameterName} must contain at least one alphanumeric character.") { }
}
