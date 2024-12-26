using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using unihub_api.Dominio.Entidades;

namespace unihub_api.Infraestrutura.ConfiguracaoEntidades
{
    public class NotaConfiguracao : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Valor)
                   .IsRequired();

            builder.Property(x => x.DataAvaliacao)
                   .IsRequired();

            builder.Property(x => x.Peso)
                   .IsRequired();
        }
    }
}
