using Microsoft.Graph;
using MHT.Infrastructure.Interfaces;
using MHT.Common.Helpers;

namespace MHT.Infrastructure.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly GraphServiceClient _graphClient;

        public CalendarService(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        public async Task<Calendar?> AssignCalendarEventsToUserAsync(User coworker)
        {
            if (_graphClient == null) return null;

            try
            {
                // Need to stay like that, because we are mocking data as for now //
                var calendar = CalendarHelper.PopulateCalendarIfEpmty();
                await Task.CompletedTask;

                return calendar;
            }
            catch (Exception exception)
            {
                throw new Exception($"Exception when filling user calendar: { exception.Message }");
            }

        }

        public async Task<IList<Event>?> GetCurrentUserCalendarForNextWeek(string graphTimeZone, List<QueryOption> viewOptions)
        {
            if (_graphClient == null) return null;

            try
            {
                var eventPage = await _graphClient
                    .Me
                    .CalendarView
                    .Request(viewOptions)
                    .Header("Prefer", $"outlook.timezone=\"{graphTimeZone}\"")
                    .Top(50)
                    .Select(e => new
                    {
                        e.Subject,
                        e.Organizer,
                        e.Attendees,
                        e.Start,
                        e.End
                    })
                    .OrderBy("start/dateTime")
                    .GetAsync();

                return eventPage.CurrentPage;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when fetching events: {ex.Message}");
            }

        }
    }
}
