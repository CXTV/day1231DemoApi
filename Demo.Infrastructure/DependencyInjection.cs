using Demo.Application.Common.Interfaces.Authentication;
using Demo.Application.Common.Interfaces.Services;
using Demo.Infrastructure.Authentication;
using Demo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Demo.Infrastructure
{
    public static class DenpendencyInjection
    {
        public static void AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
        {

           

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        }
    }
}
