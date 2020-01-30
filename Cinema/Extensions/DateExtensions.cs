using System;

namespace Cinema.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Returns if day of the week is in the weekend sat-sun
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>true if sat/sun else false</returns>
        public static bool IsWeekend(this DateTime dateTime)
        {
            var day = dateTime.DayOfWeek;
            return ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday));
        }

        public static bool IsReducedPriceDay(this DateTime dateTime)
        {
            var day = dateTime.DayOfWeek;
            return ((day == DayOfWeek.Monday) || (day == DayOfWeek.Tuesday) ||
                    (day == DayOfWeek.Wednesday) || (day == DayOfWeek.Thursday));
        }
    }
}
