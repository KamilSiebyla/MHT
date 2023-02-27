using Microsoft.Graph;
using MHT.Infrastructure.Providers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace Infrastructure.Services
{
    public class GraphClientService
    {
        private readonly IAccessTokenProviderAccessor accessor;
        private readonly HttpClient httpClient;
        private readonly ILogger<GraphClientService> logger;
        private GraphServiceClient? graphClient;

        public GraphClientService(IAccessTokenProviderAccessor accessor,
            HttpClient httpClient,
            ILogger<GraphClientService> logger)
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
