using Infrastructure.Services;
using MHT.Infrastructure.Providers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;

namespace Infrastructure.Factories
{
    public class GraphUserAccountFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        private readonly IAccessTokenProviderAccessor accessor;
        private readonly GraphClientService clientService;
        private readonly ILogger<GraphUserAccountFactory> logger;

        public GraphUserAccountFactory(IAccessTokenProviderAccessor accessor,
            GraphClientService clientService,
            ILogger<GraphUserAccountFactory> logger)
        : base(accessor)
        {
            this.accessor = accessor;
            this.clientService = clientService;
            this.logger = logger;
        }

        public async override ValueTask<ClaimsPrincipal?> CreateUserAsync(
            RemoteUserAccount account,
            RemoteAuthenticationUserOptions options)
        {
            var initialUser = await base.CreateUserAsync(account, options);

            if (initialUser?.Identity?.IsAuthenticated ?? false)
            {
                try
                {
                    await AddGraphInfoToClaims(accessor, initialUser);
                }
                catch (AccessTokenNotAvailableException exception)
                {
                    logger.LogError($"Graph API access token failure: {exception.Message}");
                }
                catch (Exception exception)
                {
                    logger.LogError($"Graph API error: {exception.Message}");
                }
            }

            return initialUser;
        }

        private async Task AddGraphInfoToClaims(
            IAccessTokenProviderAccessor accessor,
            ClaimsPrincipal claimsPrincipal)
        {
            var graphClient = clientService.GetAuthenticatedClient();

            var user = await graphClient.Me
                .Request()
                .Select(u => new {
                    u.DisplayName,
                    u.Mail,
                    u.MailboxSettings,
                    u.UserPrincipalName
                })
                .GetAsync();

            logger.LogInformation($"Got user: {user.DisplayName}");

            claimsPrincipal.AddUserGraphInfo(user);

            var photo = await graphClient.Me
                .Photos["48x48"]
                .Content
                .Request()
                .GetAsync();

            claimsPrincipal.AddUserGraphPhoto(photo);
        }
    }
}
