using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;


namespace Demo.Application
{
    public static class DenpendencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //1.获取应用程序程序集
            var applicationAssembly = typeof(DenpendencyInjection).Assembly;
            //2.注册所有MediatR处理程序
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        }
    }
}
