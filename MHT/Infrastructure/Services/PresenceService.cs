using Microsoft.Graph;
using MHT.Infrastructure.Interfaces;

namespace MHT.Infrastructure.Services
{
    public class PresenceService : IPresenceService
    {
        private readonly GraphServiceClient _graphClient;

        public PresenceService(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        public async Task<Presence?> AssignPresenceToUserAsync(User coworker)
        {
            if (_graphClient == null) return null;

            try
            {
                return await _graphClient
                    .Users[coworker.Id]
                    .Presence
                    .Request()
                    .GetAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when fetching presence: { ex.Message }");
            }
        }
    }
}
