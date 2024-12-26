using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using unihub_api.Dominio.Entidades;

namespace unihub_api.Infraestrutura.ConfiguracaoEntidades
{
    public class AtividadeConfiguracao : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Descricao)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(a => a.DataEntrega)
                .IsRequired();

            builder.Property(a => a.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.AlunoId)
                .IsRequired();

            builder.Property(a => a.DisciplinaId)
                .IsRequired();

            builder.Property(a => a.NotaId)
                .IsRequired(false);

            builder.HasOne(a => a.Aluno)
                .WithMany(a => a.Atividades)
                .HasForeignKey(a => a.AlunoId)
                .HasPrincipalKey(a => a.Id);

            builder.HasOne(a => a.Disciplina)
               .WithMany(a => a.Atividades)
               .HasForeignKey(a => a.DisciplinaId)
               .HasPrincipalKey(a => a.Id);

            builder.HasOne(a => a.Nota)
               .WithOne(a => a.Atividade);
        }
    }
}
