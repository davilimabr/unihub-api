using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unihub.Dominio.Entidades;

namespace Unihub.Infraestrutura.ConfiguracaoEntidades
{
    public class HorarioAulaConfiguracao : IEntityTypeConfiguration<HorarioAula>
    {
        public void Configure(EntityTypeBuilder<HorarioAula> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HoraInicio)
                .IsRequired();

            builder.Property(x => x.HoraTermino)
                .IsRequired();

            builder.Property(x => x.Dia)
                .IsRequired();
        }
    }
}
