using Microsoft.AspNetCore.Authentication;

namespace devtips_backend.API.Auths
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; }
    }
}
