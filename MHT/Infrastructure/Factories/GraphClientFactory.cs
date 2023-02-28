using Microsoft.Graph;
using MHT.Infrastructure.Providers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace MHT.Infrastructure.Factories
{
    public class GraphClientFactory
    {
        private readonly ILogger<GraphClientFactory> logger;
        private readonly IAccessTokenProviderAccessor accessor;
        private readonly HttpClient httpClient;
        
        private GraphServiceClient? graphClient;

        public GraphClientFactory(
            IAccessTokenProviderAccessor accessor,
            HttpClient httpClient,
            ILogger<GraphClientFactory> logger)
        {
            this.accessor = accessor;
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public GraphServiceClient GetAuthenticatedClient()
        {
            graphClient ??= new GraphServiceClient(httpClient)
            {
                AuthenticationProvider =
                    new AuthenticationProvider(accessor)
            };

            return graphClient;
        }
    }
}
