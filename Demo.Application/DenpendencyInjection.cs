using Demo.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;


namespace Demo.Application
{
    public static class DenpendencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

        }
    }
}
