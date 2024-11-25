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
    }
}
