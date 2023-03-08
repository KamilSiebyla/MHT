using Microsoft.Graph;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace MHT.Infrastructure.Providers
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly IAccessTokenProviderAccessor accessor;

        public AuthenticationProvider(IAccessTokenProviderAccessor accessor)
        {
            this.accessor = accessor;
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var result = await accessor.TokenProvider.RequestAccessToken();

            if (result.TryGetToken(out var token))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Value);
            }
        }
    }
}

