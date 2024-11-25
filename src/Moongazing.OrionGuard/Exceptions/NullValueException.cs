﻿namespace Moongazing.OrionGuard.Exceptions;

/// <summary>
/// Exception thrown when a null value is provided where it is not allowed.
/// </summary>
public class NullValueException : GuardException
{
    public NullValueException(string parameterName)
        : base($"{parameterName} cannot be null.") { }
}


