﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using unihub_api.Dominio.Entidades;

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

            builder.Property(d => d.ProfessorId)
                .IsRequired();

            builder.HasOne(d => d.Professor)
                .WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.ProfessorId)
                .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.Professor)
                .WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.ProfessorId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}