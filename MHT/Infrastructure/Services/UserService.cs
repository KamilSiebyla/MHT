using Microsoft.Graph;
using MHT.Infrastructure.Interfaces;

namespace MHT.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly GraphServiceClient _graphClient;

        public UserService(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        public async Task<User?> GetCurrentUserAsync()
        {
            if (_graphClient == null) return null;

            try
            {
                return await _graphClient
                    .Me
                    .Request()
                    .Select(u => new
                    {
                        u.DisplayName
                    })
                    .GetAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when getting user data: { ex.Message }");
            }
        }

        public async Task<IGraphServiceUsersCollectionPage?> SearchCoworkerAsync(string searchTerm)
        {
            if (_graphClient == null) return null;

            try
            {
                return await _graphClient
                    .Users
                    .Request()
                    .Select(u => new
                    {
                        u.DisplayName,
                        u.BusinessPhones,
                        u.JobTitle,
                        u.Mail,
                        u.Id
                    })
                    .Filter($"startswith(displayName, '{ searchTerm }') or startswith(surname, '{ searchTerm }')")
                    .GetAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when fetching users by search term: { ex.Message }");
            }
        }
    }
}
