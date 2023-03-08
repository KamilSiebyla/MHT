using TimeZoneConverter;

namespace MHT.Infrastructure.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetUtcStartOfWeekInTimeZone(DateTime today, string timeZoneId)
        {
            TimeZoneInfo userTimeZone = TZConvert.GetTimeZoneInfo(timeZoneId);

            int diff = System.DayOfWeek.Sunday - today.DayOfWeek;

            var unspecifiedStart = DateTime.SpecifyKind(today.AddDays(diff), DateTimeKind.Unspecified);

            return TimeZoneInfo.ConvertTimeToUtc(unspecifiedStart, userTimeZone);
        }

        public static string FormatIso8601DateTime(string iso8601DateTime, string dateTimeFormat)
        {
            var dateTime = DateTime.Parse(iso8601DateTime);

            if (!string.IsNullOrWhiteSpace(dateTimeFormat))
            {
                return dateTime.ToString(dateTimeFormat);
            }

            return iso8601DateTime;
        }
    }
}
