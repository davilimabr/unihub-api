using Microsoft.EntityFrameworkCore;
using Unihub.Dominio.Entidades;
using unihub_api.Dominio.Entidades;

namespace unihub_api.Infraestrutura.Configuracao
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<AlunosDisciplina> AlunosDisciplina { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Falta> Falta { get; set; }
        public DbSet<HorarioAula> HorarioAula { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<AulasNaSemana> AulasNaSemana { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

