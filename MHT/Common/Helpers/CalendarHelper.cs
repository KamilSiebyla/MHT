using Microsoft.Graph;

namespace MHT.Common.Helpers
{
    public static class CalendarHelper
    {
        public static Calendar PopulateCalendarIfEpmty()
        {
            return new Calendar
            {
                Events = new CalendarEventsCollectionPage
                {
                    new Event
                    {
                        Start = new DateTimeTimeZone
                        {
                            DateTime = "2023-03-08T10:00:00.0000000",
                            TimeZone = "UTC"
                        },
                        End = new DateTimeTimeZone
                        {
                            DateTime = "2023-03-08T11:00:00.0000000",
                            TimeZone = "UTC"
                        }
                    },
                    new Event
                    {
                        Start = new DateTimeTimeZone
                        {
                            DateTime = "2023-03-09T14:00:00.0000000",
                            TimeZone = "UTC"
                        },
                        End = new DateTimeTimeZone
                        {
                            DateTime = "2023-03-09T15:00:00.0000000",
                            TimeZone = "UTC"
                        }
                    },
                    new Event
                    {
                        Start = new DateTimeTimeZone
                        {
                            DateTime = "2023-03-10T09:00:00.0000000",
                            TimeZone = "UTC"
                        },
                        End = new DateTimeTimeZone
                        {
                            DateTime = "2023-03-10T12:00:00.0000000",
                            TimeZone = "UTC"
                        }
                    }
                }
            };

        }
    }
}
