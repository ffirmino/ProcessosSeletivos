using Microsoft.Extensions.DependencyInjection;
using Webmotors.Domain.Repositories;
using Webmotors.Infra.Repositories.AnuncioRepository;
using Webmotors.Service.Interfaces;
using Webmotors.Service.Services;

namespace Webmotors.API
{
    public static class Register
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            // Repositories
            services.AddTransient<IAnuncioRepository, AnuncioRepository>();

            // Services
            services.AddTransient<IAnuncioService, AnuncioService>();
        }
    }
}
