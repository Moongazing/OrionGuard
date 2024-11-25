namespace Moongazing.OrionGuard.Extensions
{
    /// <summary>
    /// Provides validation methods for DateTime values.
    /// </summary>
    public static class DateTimeGuards
    {
        public static void AgainstPastDate(this DateTime date, string parameterName)
        {
            if (date < DateTime.Now)
            {
                throw new ArgumentException($"{parameterName} cannot be in the past.", parameterName);
            }
        }

        public static void AgainstFutureDate(this DateTime date, string parameterName)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentException($"{parameterName} cannot be in the future.", parameterName);
            }
        }
    }
}
