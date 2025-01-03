using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unihub.Dominio.Entidades;

namespace Unihub.Infraestrutura.ConfiguracaoEntidades
{
    public class AlunoConfiguracao : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Matricula)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.Senha)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
