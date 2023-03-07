using Microsoft.Graph;

namespace MHT.Infrastructure.Interfaces
{
    public interface ICustomMessageService
    {
        public Task SendTeamsMessageAsync(User coworker);

        public Task SendOutlookMessageAsync(User coworker);
    }
}
