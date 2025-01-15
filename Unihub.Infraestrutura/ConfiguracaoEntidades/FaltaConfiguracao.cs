using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unihub.Dominio.Entidades;

namespace Unihub.Infraestrutura.ConfiguracaoEntidades
{
    public class FaltaConfiguracao : IEntityTypeConfiguration<Falta>
    {
        public void Configure(EntityTypeBuilder<Falta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data)
                   .IsRequired();

            builder.Property(x => x.Motivo)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasOne(x => x.Aluno)
                   .WithMany(x => x.Faltas)
                   .HasForeignKey(x => x.AlunoId)
                   .HasPrincipalKey(x => x.Id);

            builder.HasOne(x => x.Disciplina)
                   .WithMany(x => x.Faltas)
                   .HasForeignKey(x => x.DisciplinaId)
                   .HasPrincipalKey(x => x.Id);
        }
    }
}
