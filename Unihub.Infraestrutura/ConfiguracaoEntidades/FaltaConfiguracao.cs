using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using unihub_api.Dominio.Entidades;

namespace unihub_api.Infraestrutura.ConfiguracaoEntidades
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
                   .HasForeignKey(x => x.AlunoId);
        }
    }
}
