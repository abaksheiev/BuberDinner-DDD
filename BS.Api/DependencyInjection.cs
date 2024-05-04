using BS.Api.Common.Errors;
using BS.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BS.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, BSProblemDetailsFactory>();

            services.AddMappings();
            return services;
        }
    }
}
