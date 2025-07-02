using Moongazing.OrionGuard.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Moongazing.OrionGuard.Core;

public static class Guard
{
    public static GuardBuilder<T> For<T>(T value, string parameterName)
    {
        return new GuardBuilder<T>(value, parameterName);
    }
    public static void AgainstNull<T>(T? value, string parameterName) where T : class
    {
        if (value == null)
        {
            throw new NullValueException(parameterName);
        }
    }

    public static void AgainstNullOrEmpty(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyStringException(parameterName);
        }
    }

    public static void AgainstOutOfRange<T>(T value, T min, T max, string parameterName) where T : IComparable
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
        {
            throw new OutOfRangeException(parameterName, min, max);
        }
    }
    public static void AgainstNegative(this int value, string parameterName)
    {
        if (value < 0)
        {
            throw new NegativeException(parameterName);
        }
    }

    public static void AgainstNegativeDecimal(this decimal value, string parameterName)
    {
        if (value < 0)
        {
            throw new NegativeDecimalException(parameterName);
        }
    }

    public static void AgainstLessThan(this int value, int minValue, string parameterName)
    {
        if (value < minValue)
        {
            throw new LessThanException(parameterName);
        }
    }

    public static void AgainstGreaterThan(this int value, int maxValue, string parameterName)
    {
        if (value > maxValue)
        {
            throw new GreaterThanException(parameterName);
        }
    }

    public static void AgainstOutOfRange(this int value, int minValue, int maxValue, string parameterName)
    {
        if (value < minValue || value > maxValue)
        {
            throw new OutOfRangeException(parameterName, minValue, maxValue);
        }
    }

    public static void AgainstFalse(this bool value, string parameterName)
    {
        if (!value)
        {
            throw new FalseException(parameterName);
        }
    }

    public static void AgainstTrue(this bool value, string parameterName)
    {
        if (value)
        {
            throw new TrueException(parameterName);
        }
    }

    public static void AgainstUninitializedProperties<T>(this T obj, string parameterName)
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            if (property.GetValue(obj) == null)
            {
                throw new UninitializedPropertyException($"{parameterName} contains uninitialized property: {property.Name}.", parameterName);
            }
        }
    }


    public static void AgainstInvalidEmail(string email, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(email) ||
            !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new InvalidEmailException(parameterName);
        }
    }

    public static void AgainstInvalidUrl(string value, string parameterName)
    {
        if (!Uri.TryCreate(value, UriKind.Absolute, out var uriResult) ||
            !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        {
            throw new InvalidUrlException(parameterName);
        }
    }

    public static void AgainstInvalidIp(string ipAddress, string parameterName)
    {
        if (!System.Net.IPAddress.TryParse(ipAddress, out _))
        {
            throw new InvalidIpException(parameterName);
        }
    }

    public static void AgainstInvalidGuid(string value, string parameterName)
    {
        if (!Guid.TryParse(value, out _))
        {
            throw new InvalidGuidException(parameterName);
        }
    }

    public static void AgainstPastDate(DateTime date, string parameterName)
    {
        if (date < DateTime.Now)
        {
            throw new PastDateException(parameterName);
        }
    }

    public static void AgainstFutureDate(DateTime date, string parameterName)
    {
        if (date > DateTime.Now)
        {
            throw new FutureDateException(parameterName);
        }
    }

    public static void AgainstEmptyFile(string filePath, string parameterName)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotExistsException(parameterName);
        }

        var fileInfo = new FileInfo(filePath);
        if (fileInfo.Length == 0)
        {
            throw new EmptyFileException(parameterName);
        }
    }

    public static void AgainstInvalidFileExtension(string filePath, string[] validExtensions, string parameterName)
    {
        var extension = Path.GetExtension(filePath);
        if (!validExtensions.Contains(extension))
        {
            throw new InvalidFileExtensionException($"{parameterName} must have one of the following extensions: {string.Join(", ", validExtensions)}.");
        }
    }

    public static void AgainstNonAlphanumericCharacters(string value, string parameterName)
    {
        if (!Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
        {
            throw new OnlyAlphanumericCharacterException($"{parameterName} must contain only alphanumeric characters.");
        }
    }

    public static void AgainstWeakPassword(string value, string parameterName)
    {
        if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
        {
            throw new WeakPasswordException($"{parameterName} must be a strong password (at least 8 characters, including uppercase, lowercase, number, and special character).");
        }
    }

    public static void AgainstExceedingCount<T>(IEnumerable<T> collection, int maxCount, string parameterName)
    {
        if (collection.Count() > maxCount)
        {
            throw new ExceedingCountException(parameterName, maxCount);
        }
    }

    public static void AgainstEmptyCollection<T>(IEnumerable<T> collection, string parameterName)
    {
        if (collection == null || !collection.Any())
        {
            throw new EmptyStringException(parameterName);
        }
    }

    public static void AgainstNullItems<T>(IEnumerable<T?> collection, string parameterName)
    {
        if (collection.Any(item => item == null))
        {
            throw new NullValueException($"{parameterName} contains null items.");
        }
    }

    public static void AgainstInvalidEnum<TEnum>(TEnum value, string parameterName) where TEnum : struct, Enum
    {
        if (!Enum.IsDefined(typeof(TEnum), value))
        {
            throw new InvalidEnumValueException(parameterName);
        }
    }

    public static void AgainstInvalidXml(string xmlContent, string parameterName)
    {
        try
        {
            System.Xml.Linq.XDocument.Parse(xmlContent);
        }
        catch
        {
            throw new InvalidXmlException(parameterName);
        }
    }

    public static void AgainstUnrealisticBirthDate(DateTime date, string parameterName)
    {
        var maxDate = DateTime.Now.AddYears(-120);
        if (date > DateTime.Now || date < maxDate)
        {
            throw new UnrealisticBirthDateException($"{parameterName} is not a realistic birth date.");
        }
    }

    public static void AgainstCharactersOutsideSet(string value, string allowedCharacters, string parameterName)
    {
        if (!Regex.IsMatch(value, $"^[{Regex.Escape(allowedCharacters)}]+$"))
        {
            throw new CharactersOutsideSetException($"{parameterName} must only contain characters from the allowed set '{allowedCharacters}'.");
        }
    }

}
