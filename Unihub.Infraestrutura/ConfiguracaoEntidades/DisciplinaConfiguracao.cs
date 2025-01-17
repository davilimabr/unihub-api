using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unihub.Dominio.Entidades;

namespace Unihub.Infraestrutura.ConfiguracaoEntidades
{
    public class DisciplinaConfiguracao : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Codigo)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.Descricao)
                .HasMaxLength(500);

            builder.Property(d => d.Sala)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.TotalHoras)
                .IsRequired();

            builder.Property(d => d.Periodo)
                .IsRequired();

            builder.Property(d => d.Obrigatoria)
                .IsRequired();
        }
    }
}
