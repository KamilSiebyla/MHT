using Microsoft.Graph;

namespace MHT.Infrastructure.Interfaces
{
    public interface ICalendarService
    {
        Task<Calendar?> AssignCalendarEventsToUserAsync(User coworker);

        Task<IList<Event>?> GetCurrentUserCalendarForNextWeek(string graphTimeZone, List<QueryOption> viewOptions);
    }
}
