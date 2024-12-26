using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using unihub_api.Dominio.Entidades;

namespace Unihub.Infraestrutura.ConfiguracaoEntidades
{
    public class AlunosDisciplinaConfiguracao : IEntityTypeConfiguration<AlunosDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunosDisciplina> builder)
        {
            builder.HasKey(ad => ad.Id);

            builder.Property(ad => ad.AlunoId)
                .IsRequired();

            builder.Property(ad => ad.DisciplinaId)
                .IsRequired();

            builder.HasOne(ad => ad.Aluno)
                .WithMany(a => a.AlunosDisciplinas)
                .HasForeignKey(ad => ad.AlunoId)
                .HasPrincipalKey(a => a.Id);

            builder.HasOne(ad => ad.Disciplina)
               .WithMany(a => a.AlunosDisciplinas)
               .HasForeignKey(ad => ad.DisciplinaId)
               .HasPrincipalKey(a => a.Id);
        }
    }
}
