using BS.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
