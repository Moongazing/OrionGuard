using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Moongazing.OrionGuard.Core
{
    public static class Guard
    {
        public static void Against<TException>(bool condition, string message) where TException : Exception, new()
        {
            if (condition)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message)!;
            }
        }

        public static void AgainstNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void AgainstNullOrEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{parameterName} cannot be null or empty.", parameterName);
            }
        }

        public static void AgainstOutOfRange<T>(T value, T min, T max, string parameterName) where T : IComparable
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be between {min} and {max}.");
            }
        }

        public static void AgainstFalse(bool value, string parameterName)
        {
            if (!value)
            {
                throw new ArgumentException($"{parameterName} cannot be false.", parameterName);
            }
        }

        public static void AgainstTrue(bool value, string parameterName)
        {
            if (value)
            {
                throw new ArgumentException($"{parameterName} cannot be true.", parameterName);
            }
        }

        public static void AgainstNullOrEmpty<T>(IEnumerable<T> collection, string parameterName)
        {
            if (collection == null || !collection.Any())
            {
                throw new ArgumentException($"{parameterName} cannot be null or empty.", parameterName);
            }
        }

        public static void AgainstExceedingCount<T>(IEnumerable<T> collection, int maxCount, string parameterName)
        {
            if (collection.Count() > maxCount)
            {
                throw new ArgumentException($"{parameterName} cannot contain more than {maxCount} items.", parameterName);
            }
        }

        public static void AgainstNullItems<T>(IEnumerable<T> collection, string parameterName)
        {
            if (collection.Any(item => item == null))
            {
                throw new ArgumentException($"{parameterName} cannot contain null items.", parameterName);
            }
        }

        public static void AgainstPastDate(DateTime date, string parameterName)
        {
            if (date < DateTime.Now)
            {
                throw new ArgumentException($"{parameterName} cannot be in the past.", parameterName);
            }
        }

        public static void AgainstFutureDate(DateTime date, string parameterName)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentException($"{parameterName} cannot be in the future.", parameterName);
            }
        }

        public static void AgainstDateRange(DateTime date, DateTime startDate, DateTime endDate, string parameterName)
        {
            if (date < startDate || date > endDate)
            {
                throw new ArgumentException($"{parameterName} must be between {startDate} and {endDate}.", parameterName);
            }
        }

        public static void AgainstWeekend(DateTime date, string parameterName)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new ArgumentException($"{parameterName} cannot be on a weekend.", parameterName);
            }
        }

        public static void AgainstSpecificDay(DateTime date, DayOfWeek day, string parameterName)
        {
            if (date.DayOfWeek == day)
            {
                throw new ArgumentException($"{parameterName} cannot be on {day}.", parameterName);
            }
        }

        public static void AgainstNegative(int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be negative.");
            }
        }

        public static void AgainstZero(int value, string parameterName)
        {
            if (value == 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero.", parameterName);
            }
        }

        public static void AgainstOutOfRange(int value, int minValue, int maxValue, string parameterName)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be between {minValue} and {maxValue}.");
            }
        }

        public static void AgainstNonNumericCharacters(string value, string parameterName)
        {
            if (!Regex.IsMatch(value, @"^\d+$"))
            {
                throw new ArgumentException($"{parameterName} must contain only numeric characters.", parameterName);
            }
        }

        public static void AgainstInvalidEmail(string email, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ArgumentException($"{parameterName} must be a valid email address.", parameterName);
            }
        }

        public static void AgainstInvalidUrl(string value, string parameterName)
        {
            if (!Uri.TryCreate(value, UriKind.Absolute, out var uriResult) ||
                !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                throw new ArgumentException($"{parameterName} must be a valid URL.", parameterName);
            }
        }

        public static void AgainstNonExistentFile(string filePath, string parameterName)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"{parameterName} does not exist.", parameterName);
            }
        }

        public static void AgainstEmptyFile(string filePath, string parameterName)
        {
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Length == 0)
            {
                throw new ArgumentException($"{parameterName} cannot be an empty file.", parameterName);
            }
        }
    }
}
