using System.Text;

using BS.Application.Common.Interfaces.Authentication;
using BS.Application.Common.Interfaces.Services;
using BS.Application.Persistence;
using BS.Infrastructure.Authentication;
using BS.Infrastructure.Persistence;
using BS.Infrastructure.Persistence.Interceptors;
using BS.Infrastructure.Persistence.Repositories;
using BS.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistence();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<BSDbContext>(options =>
                     options.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=WebCqrs;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<PublishDomainEventsInterceptor>();
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configration)
        {
            var jwtSettings = new JwtSettings();
            configration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Secret))
                    });

            return services;
        }
    }
}
