using System;

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
        public static void AgainstDateRange(this DateTime date, DateTime startDate, DateTime endDate, string parameterName)
        {
            if (date < startDate || date > endDate)
            {
                throw new ArgumentException($"{parameterName} must be between {startDate} and {endDate}.", parameterName);
            }
        }

        public static void AgainstWeekend(this DateTime date, string parameterName)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new ArgumentException($"{parameterName} cannot be on a weekend.", parameterName);
            }
        }

        public static void AgainstTimeRange(this DateTime date, TimeSpan startTime, TimeSpan endTime, string parameterName)
        {
            var time = date.TimeOfDay;
            if (time < startTime || time > endTime)
            {
                throw new ArgumentException($"{parameterName} must be between {startTime} and {endTime}.", parameterName);
            }
        }
        public static void AgainstNonToday(this DateTime date, string parameterName)
        {
            if (date.Date != DateTime.Now.Date)
            {
                throw new ArgumentException($"{parameterName} must be today's date.", parameterName);
            }
        }

    }
}
