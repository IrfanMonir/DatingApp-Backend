using Api.Interfaces;
using Api.Services;

namespace Api.DependencyInjection
{
    public static class ServicesRegister
    {
        public static void AddServices(this IServiceCollection services) => services
            .AddScoped<ITokenService,TokenService>();
    }
}
