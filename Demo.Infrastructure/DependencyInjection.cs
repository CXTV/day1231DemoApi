using Demo.Application.Common.Interfaces;
using Demo.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure
{
    public static class DenpendencyInjection
    {
        public static void AddInfrustructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        }
    }
}
