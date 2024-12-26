using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using unihub_api.Dominio.Entidades;

namespace unihub_api.Infraestrutura.ConfiguracaoEntidades
{
    public class ProfessorConfiguracao : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            // Exemplo de 1-N para Disciplina (caso queira explicitar):
            // builder.HasMany<Disciplina>()
            //        .WithOne()
            //        .HasForeignKey("ProfessorId");
        }
    }
}
