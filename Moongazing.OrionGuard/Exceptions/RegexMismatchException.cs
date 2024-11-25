namespace Moongazing.OrionGuard.Exceptions;

/// <summary>
/// Exception thrown when a string does not match a regex pattern.
/// </summary>
public class RegexMismatchException : GuardException
{
    public RegexMismatchException(string parameterName, string pattern)
        : base($"{parameterName} does not match the required pattern: {pattern}") { }
}
