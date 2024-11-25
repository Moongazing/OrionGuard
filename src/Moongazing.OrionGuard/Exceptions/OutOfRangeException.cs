﻿namespace Moongazing.OrionGuard.Exceptions;


/// <summary>
/// Exception thrown when a value is outside the specified range.
/// </summary>
public class OutOfRangeException : GuardException
{
    public OutOfRangeException(string parameterName, object min, object max)
        : base($"{parameterName} must be between {min} and {max}.") { }
}
