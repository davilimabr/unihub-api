using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unihub.Dominio.Entidades;

namespace Unihub.Infraestrutura.ConfiguracaoEntidades
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
