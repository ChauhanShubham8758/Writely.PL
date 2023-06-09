using System.Globalization;
using System.Diagnostics;

namespace Writely.Common.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime MaxDate = new DateTime(0x270f, 12, 0x1f, 0x17, 0x3b, 0x3b, 0x3e7);
        private static readonly DateTime MinDate = new DateTime(0x76c, 1, 1);

        [DebuggerStepThrough]
        public static bool IsValid(this DateTime target)
        {
            return ((target >= MinDate) && (target <= MaxDate));
        }

        public static DateTime GetDateAtTime(this DateTime dateTime, int hour, int minute, int second)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, second);
        }

        /// <summary>
        /// Gets the Date and Time from yyyy-MM-DD-HH-mm format.
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool GetDateFromHyphenatedString(this string strDate, out DateTime date)
        {
            var dateTokens = strDate.Split('-');
            if (dateTokens.Length != 5)
            {
                date = DateTime.MinValue;
                return false;
            }

            var parseableDate =
                $"{dateTokens[0]}-{dateTokens[1]}-{dateTokens[2]}T{dateTokens[3]}:{dateTokens[4]}";
            return DateTime.TryParse(parseableDate, out date);
        }

        public static DateTime GetEndOfDayDateTime(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 0);
        }

        /// <summary>
        ///     Ref: http://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int GetIso8601WeekOfYear(this DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                time = time.AddDays(3);

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
        }

        public static DateTime GetLastDayOfTheYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 12, 31, 23, 59, 0);
        }

        public static DateTime GetStartOfDayDateTime(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }

        public static List<DateTime> GetUniqueDatesOnly(this List<DateTime> occurrenceDateTimes)
        {
            return occurrenceDateTimes.Select(x => x.Date).Distinct().ToList();
        }

        public static bool HasElapsed(this DateTime occurrence, int? cutOffInMinutes, string timeZoneId)
        {
            var occurrenceTimeInUtc = occurrence.ToUtcWithDaylightSavingsAdjustment(timeZoneId);
            var cutOffTime = occurrenceTimeInUtc.AddMinutes(-1 * cutOffInMinutes.GetValueOrDefault());

            return DateTime.UtcNow > cutOffTime;
        }

        public static bool HasElapsed(this DateTime dateTime, DateTime dateToCompare)
        {
            return dateTime < dateToCompare;
        }

        public static bool HasElapsedUtc(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return DateTime.UtcNow > dateTime;

            return false;
        }

        public static DateTime SpecifyUtc(this DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }

        public static DateTime ToUtcWithDaylightSavingsAdjustment(this DateTime date, string timeZoneId)
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            //var tz = GetTimeZone(timeZoneId);

            var startOffset = tz.IsDaylightSavingTime(date)
                ? tz.BaseUtcOffset.TotalHours + 1
                : tz.BaseUtcOffset.TotalHours;

            return DateTime.SpecifyKind(date.AddHours(-1 * startOffset), DateTimeKind.Utc);
        }

        public static DateTime ToSpecifiedTimeZoneFromUtcWithDaylightAdjustment(this DateTime date, string timeZoneId)
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            //var tz = GetTimeZone(timeZoneId);
            var startOffset = tz.IsDaylightSavingTime(date)
                ? tz.BaseUtcOffset.TotalHours + 1
                : tz.BaseUtcOffset.TotalHours;

            return DateTime.SpecifyKind(date.AddHours(startOffset), DateTimeKind.Local);
        }

        public static DateTime ConvertFromDate(this int dateKey)
        {
            return DateTime.ParseExact(dateKey.ToString(),
                "yyyyMMdd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None);

        }

        public static DateTime ConvertFromMonth(this int monthKey)
        {
            return DateTime.ParseExact($"{monthKey.ToString()}01",
                "yyyyMMdd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None);

        }

        #region INTERVAL METHODS

        // private static TimeZoneInfo GetTimeZone(string timeZoneId)
        // {
        //     try
        //     {
        //         var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        //         if (tz != null)
        //         {
        //             return tz;
        //         }
        //     }
        //     catch (TimeZoneNotFoundException ex)
        //     {
        //         var linuxTz = TZConvert.GetTimeZoneInfo(timeZoneId);
        //         if (linuxTz == null)
        //         {
        //             throw new ArgumentException("Unknown Timezone");
        //         }
        //
        //         return linuxTz;
        //     }
        //
        //     throw new TimeZoneNotFoundException($"TimeZone: {timeZoneId} not found.");
        //     
        //
        // }

        #endregion

    }
}
