using Microsoft.Graph;

namespace MHT.Infrastructure.Interfaces
{
    public interface IPresenceService
    {
        Task<Presence?> AssignPresenceToUserAsync(User coworker);
    }
}
