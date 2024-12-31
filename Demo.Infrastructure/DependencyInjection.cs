using Demo.Application.Common.Interfaces.Authentication;
using Demo.Application.Common.Interfaces.Services;
using Demo.Infrastructure.Authentication;
using Demo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure
{
    public static class DenpendencyInjection
    {
        public static void AddInfrustructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        }
    }
}
