using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unihub.Aplicacao.Interfaces;
using Unihub.Aplicacao.Mapeamentos;
using Unihub.Aplicacao.Servicos;
using Unihub.Dominio.Interfaces;
using Unihub.Infraestrutura.Contexto;
using Unihub.Infraestrutura.Repositorio;

namespace Unihub.Ioc
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

            services.AddAutoMapper(typeof(DtoParaDominioMapeamentos));

            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<IDisciplinaRepositorio, DisciplinaRepositorio>();
            services.AddScoped<IAtividadeRepositorio, AtividadeRepositorio>();
            services.AddScoped<IFaltaRepositorio, FaltaRepositorio>();


            services.AddScoped<IAlunoServico, AlunoServico>();
            services.AddScoped<IDisciplinaServico, DisciplinaServico>();
            services.AddScoped<IAtividadeServico, AtividadeServico>();

            return services;
        }
    }
}
