using Moongazing.OrionGuard.Exceptions;
using System.Text.RegularExpressions;

namespace Moongazing.OrionGuard.Extensions;

/// <summary>
/// Provides validation methods for strings.
/// </summary>
public static class StringGuards
{
    /// <summary>
    /// Validates that a string is not null or empty.
    /// </summary>
    public static void AgainstNullOrEmpty(this string value, string parameterName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"{parameterName} cannot be null or empty.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string is not null, empty, or whitespace.
    /// </summary>
    public static void AgainstNullOrWhiteSpace(this string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} cannot be null, empty, or whitespace.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string does not contain only whitespace characters.
    /// </summary>
    public static void AgainstOnlyWhiteSpace(this string value, string parameterName)
    {
        if (!string.IsNullOrEmpty(value) && value.Trim().Length == 0)
        {
            throw new ArgumentException($"{parameterName} cannot consist only of whitespace.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string's length is within a specified range.
    /// </summary>
    public static void AgainstInvalidLength(this string value, int minLength, int maxLength, string parameterName)
    {
        if (value.Length < minLength || value.Length > maxLength)
        {
            throw new ArgumentException($"{parameterName} must be between {minLength} and {maxLength} characters long.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string contains only letters.
    /// </summary>
    public static void AgainstNonAlphabeticCharacters(this string value, string parameterName)
    {
        if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
        {
            throw new ArgumentException($"{parameterName} must contain only alphabetic characters.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string contains only digits.
    /// </summary>
    public static void AgainstNonNumericCharacters(this string value, string parameterName)
    {
        if (!Regex.IsMatch(value, @"^\d+$"))
        {
            throw new ArgumentException($"{parameterName} must contain only numeric characters.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string contains only alphanumeric characters.
    /// </summary>
    public static void AgainstNonAlphanumericCharacters(this string value, string parameterName)
    {
        if (!Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
        {
            throw new ArgumentException($"{parameterName} must contain only alphanumeric characters.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string starts with a specific substring.
    /// </summary>
    public static void AgainstNotStartingWith(this string value, string prefix, string parameterName)
    {
        if (!value.StartsWith(prefix))
        {
            throw new ArgumentException($"{parameterName} must start with '{prefix}'.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string ends with a specific substring.
    /// </summary>
    public static void AgainstNotEndingWith(this string value, string suffix, string parameterName)
    {
        if (!value.EndsWith(suffix))
        {
            throw new ArgumentException($"{parameterName} must end with '{suffix}'.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string contains only ASCII characters.
    /// </summary>
    public static void AgainstNonAsciiCharacters(this string value, string parameterName)
    {
        if (!Regex.IsMatch(value, @"^[\x00-\x7F]+$"))
        {
            throw new ArgumentException($"{parameterName} must contain only ASCII characters.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string contains only Unicode characters.
    /// </summary>
    public static void AgainstNonUnicodeCharacters(this string value, string parameterName)
    {
        if (!Regex.IsMatch(value, @"^\P{C}+$"))
        {
            throw new ArgumentException($"{parameterName} must contain only Unicode characters.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string matches a specific regex pattern.
    /// </summary>
    public static void AgainstRegexMismatch(this string value, string pattern, string parameterName)
    {
        if (!Regex.IsMatch(value, pattern))
        {
            throw new ArgumentException($"{parameterName} does not match the required pattern.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string does not contain a specific substring.
    /// </summary>
    public static void AgainstContainingSubstring(this string value, string forbiddenSubstring, string parameterName)
    {
        if (value.Contains(forbiddenSubstring))
        {
            throw new ArgumentException($"{parameterName} must not contain the forbidden substring '{forbiddenSubstring}'.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string is all uppercase.
    /// </summary>
    public static void AgainstNotAllUppercase(this string value, string parameterName)
    {
        if (value != value.ToUpperInvariant())
        {
            throw new ArgumentException($"{parameterName} must be all uppercase.", parameterName);
        }
    }

    /// <summary>
    /// Validates that a string is all lowercase.
    /// </summary>
    public static void AgainstNotAllLowercase(this string value, string parameterName)
    {
        if (value != value.ToLowerInvariant())
        {
            throw new ArgumentException($"{parameterName} must be all lowercase.", parameterName);
        }
    }

    /// <summary>
    /// Validates that the provided string is a valid email address.
    /// </summary>
    /// <param name="email">The email string to validate.</param>
    /// <param name="parameterName">The parameter name for error messages.</param>
    public static void AgainstInvalidEmail(this string email, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(email) ||
            !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new InvalidEmailException(parameterName);
        }
    }
}
