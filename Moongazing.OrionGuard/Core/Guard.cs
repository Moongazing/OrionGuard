namespace Moongazing.OrionGuard.Core;

using Moongazing.OrionGuard.Exceptions;
using System;

/// <summary>
/// Provides core static methods for validating input parameters.
/// </summary>
public static class Guard
{
    /// <summary>
    /// Validates a condition and throws a specified exception if the condition is true.
    /// </summary>
    /// <typeparam name="TException">The type of exception to throw.</typeparam>
    /// <param name="condition">The condition to evaluate.</param>
    /// <param name="message">The exception message.</param>
    public static void Against<TException>(bool condition, string message) where TException : GuardException, new()
    {
        if (condition)
        {
            throw (TException)Activator.CreateInstance(typeof(TException), message)!;
        }
    }

    /// <summary>
    /// Validates that a value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstNull<T>(T value, string parameterName) where T : class
    {
        if (value == null)
        {
            throw new NullValueException(parameterName);
        }
    }

    /// <summary>
    /// Validates that a string is not null, empty, or whitespace.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstNullOrEmpty(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyStringException(parameterName);
        }
    }

    /// <summary>
    /// Validates that a numeric value is within a specified range.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="min">The minimum allowed value.</param>
    /// <param name="max">The maximum allowed value.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstOutOfRange<T>(T value, T min, T max, string parameterName) where T : IComparable
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
        {
            throw new OutOfRangeException(parameterName, min, max);
        }
    }

    /// <summary>
    /// Validates that an enum value is defined within the specified enum type.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="value">The enum value to validate.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstInvalidEnum<TEnum>(TEnum value, string parameterName) where TEnum : struct, Enum
    {
        if (!Enum.IsDefined(typeof(TEnum), value))
        {
            throw new InvalidEnumValueException(parameterName);
        }
    }

    /// <summary>
    /// Validates that a date is not in the future.
    /// </summary>
    /// <param name="date">The date to validate.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstFutureDate(DateTime date, string parameterName)
    {
        if (date > DateTime.Now)
        {
            throw new FutureDateException(parameterName);
        }
    }

    /// <summary>
    /// Validates that a date is not in the past.
    /// </summary>
    /// <param name="date">The date to validate.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstPastDate(DateTime date, string parameterName)
    {
        if (date < DateTime.Now)
        {
            throw new PastDateException(parameterName);
        }
    }

    /// <summary>
    /// Validates that a string matches a specific regex pattern.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="pattern">The regex pattern to match.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstRegexMismatch(string value, string pattern, string parameterName)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, pattern))
        {
            throw new RegexMismatchException(parameterName, pattern);
        }
    }

    /// <summary>
    /// Validates that an email is valid.
    /// </summary>
    /// <param name="email">The email string to validate.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstInvalidEmail(string email, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(email) ||
            !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new InvalidEmailException(parameterName);
        }
    }


    /// <summary>
    /// Validates that a decimal value is not negative.
    /// </summary>
    /// <param name="value">The decimal value to validate.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstNegativeDecimal(decimal value, string parameterName)
    {
        if (value < 0)
        {
            throw new NegativeDecimalException(parameterName);
        }
    }

}
