using Microsoft.Graph;

namespace MHT.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<IGraphServiceUsersCollectionPage?> SearchCoworkerAsync(string searchTerm);

        Task<User?> GetCurrentUserAsync();
    }
}
