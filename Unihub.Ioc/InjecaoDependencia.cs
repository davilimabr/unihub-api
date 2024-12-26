using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using unihub_api.Infraestrutura.Configuracao;

namespace unihub_api.Ioc
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AdicionarInfraestrutura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
             options.UseMySql(
                 configuration.GetConnectionString("BancoDeDados"),
                 new MySqlServerVersion(new Version(8, 0, 21)),
                 b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                 ));

            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetClubHandler))));


            //services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}
