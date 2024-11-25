namespace Moongazing.OrionGuard.Exceptions;

/// <summary>
/// Base exception for all guard-related errors.
/// </summary>
public class GuardException : Exception
{
    public GuardException(string message) : base(message) { }

    public GuardException(string message, Exception innerException) : base(message, innerException) { }
}
