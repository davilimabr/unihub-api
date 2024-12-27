using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unihub.Dominio.Entidades;

namespace Unihub.Infraestrutura.ConfiguracaoEntidades
{
    public class AulasNaSemanaConfiguracao : IEntityTypeConfiguration<AulasNaSemana>
    {
        public void Configure(EntityTypeBuilder<AulasNaSemana> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.DisciplinaId)
                .IsRequired();

            builder.Property(a => a.HorarioAulaId)
                .IsRequired();

            builder.HasOne(a => a.Disciplina)
                .WithMany(d => d.AulasNaSemanas)
                .HasForeignKey(a => a.DisciplinaId)
                .HasPrincipalKey(a => a.Id);

            builder.HasOne(a => a.HorarioAula)
                .WithMany(h => h.AulasNaSemanas)
                .HasForeignKey(a => a.HorarioAulaId)
                .HasPrincipalKey(a => a.Id);
        }
    }
}
