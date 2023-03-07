using Microsoft.Graph;

namespace MHT.Common.Helpers
{
    public static class QueryOptionsHelper
    {
        public static List<QueryOption> BuildStartEndDatesFilterQueryForCalendar()
        {
            var startOfWeek = DateTime.Today;
            var endOfWeek = startOfWeek.AddDays(7);

            return new List<QueryOption>
            {
                new QueryOption("startDateTime", startOfWeek.ToString("o")),
                new QueryOption("endDateTime", endOfWeek.ToString("o"))
            };
        }
    }
}
