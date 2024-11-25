namespace Moongazing.OrionGuard.Exceptions;

/// <summary>
/// Exception thrown when an empty or whitespace string is provided.
/// </summary>
public class EmptyStringException : GuardException
{
    public EmptyStringException(string parameterName)
        : base($"{parameterName} cannot be null or empty.") { }
}
