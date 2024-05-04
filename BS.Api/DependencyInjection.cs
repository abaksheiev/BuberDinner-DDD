using BS.Application.Common.Errors;
using BS.Application.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BS.Application
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
