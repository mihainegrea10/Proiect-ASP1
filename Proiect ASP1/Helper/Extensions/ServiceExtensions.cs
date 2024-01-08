using Proiect_ASP1.Helper.Seeders;
using Proiect_ASP1.Repositories.ImpresarRepository;
using Proiect_ASP1.Services.DemoService;

namespace Proiect_ASP1.Helper.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IImpresarRepository, ImpresarRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDemoService,DemoService>();
            return services;
        }
        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<AntrenorSeeder>();
            return services;
        }
    }
}
