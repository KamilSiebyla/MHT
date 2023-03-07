using Microsoft.Graph;

namespace MHT.Infrastructure.Interfaces
{
    public interface ICustomMessageService
    {
        public Task SendTeamsMessage(User coworker);

        public Task SendOutlookMessage(User coworker);
    }
}
