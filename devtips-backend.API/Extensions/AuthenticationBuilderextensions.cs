using devtips_backend.API.Auths;
using Microsoft.AspNetCore.Authentication;

namespace devtips_backend.API.Extensions
{
    public static class AuthenticationBuilderextensions
    {
        public static AuthenticationBuilder AddApiKeySupport(this AuthenticationBuilder builder)
        {
            return builder.AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKey", options =>
            {
                options.ApiKey = "bewareoblivionisathend";
            });
        }
    }
}
