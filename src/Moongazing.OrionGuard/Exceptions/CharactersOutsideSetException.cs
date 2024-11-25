namespace Moongazing.OrionGuard.Exceptions;

public class CharactersOutsideSetException : GuardException
{
    public CharactersOutsideSetException(string parameterName)
        : base($"{parameterName} contains characters outside the set.") { }
}
