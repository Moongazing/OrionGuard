using System;

namespace Moongazing.OrionGuard.Extensions
{
    /// <summary>
    /// Provides validation methods for numeric values.
    /// </summary>
    public static class NumericGuards
    {
        public static void AgainstNegative(this int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be negative.");
            }
        }

        public static void AgainstNegativeDecimal(this decimal value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} cannot be negative.");
            }
        }
        public static void AgainstLessThan(this int value, int minValue, string parameterName)
        {
            if (value < minValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be at least {minValue}.");
            }
        }

        public static void AgainstLessThan(this decimal value, decimal minValue, string parameterName)
        {
            if (value < minValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be at least {minValue}.");
            }
        }
        public static void AgainstGreaterThan(this int value, int maxValue, string parameterName)
        {
            if (value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be at most {maxValue}.");
            }
        }

        public static void AgainstGreaterThan(this decimal value, decimal maxValue, string parameterName)
        {
            if (value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be at most {maxValue}.");
            }
        }

        public static void AgainstZero(this int value, string parameterName)
        {
            if (value == 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero.", parameterName);
            }
        }

        public static void AgainstZero(this decimal value, string parameterName)
        {
            if (value == 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero.", parameterName);
            }
        }
        public static void AgainstOutOfRange(this int value, int minValue, int maxValue, string parameterName)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be between {minValue} and {maxValue}.");
            }
        }

        public static void AgainstOutOfRange(this decimal value, decimal minValue, decimal maxValue, string parameterName)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be between {minValue} and {maxValue}.");
            }
        }
        public static void AgainstNonInteger(this decimal value, string parameterName)
        {
            if (value % 1 != 0)
            {
                throw new ArgumentException($"{parameterName} must be an integer.", parameterName);
            }
        }
        public static void AgainstCustomCondition(this int value, Func<int, bool> condition, string parameterName, string errorMessage)
        {
            if (!condition(value))
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        public static void AgainstCustomCondition(this decimal value, Func<decimal, bool> condition, string parameterName, string errorMessage)
        {
            if (!condition(value))
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }


    }
}
