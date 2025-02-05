﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unihub.Infraestrutura.Contexto;

#nullable disable

namespace Unihub.Infraestrutura.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241227171048_Criando_Entidades")]
    partial class Criando_Entidades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Unihub.Dominio.Entidades.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.AlunosDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplina");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("NotaId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("NotaId")
                        .IsUnique();

                    b.ToTable("Atividade");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.AulasNaSemana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("HorarioAulaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("HorarioAulaId");

                    b.ToTable("AulasNaSemana");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<string>("Sala")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("TotalHoras")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Falta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("HorarioAulaId")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("HorarioAulaId");

                    b.ToTable("Falta");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.HorarioAula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("HoraInicio")
                        .HasColumnType("int");

                    b.Property<int>("HoraTermino")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HorarioAula");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Nota");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.AlunosDisciplina", b =>
                {
                    b.HasOne("Unihub.Dominio.Entidades.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unihub.Dominio.Entidades.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Atividade", b =>
                {
                    b.HasOne("Unihub.Dominio.Entidades.Aluno", "Aluno")
                        .WithMany("Atividades")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unihub.Dominio.Entidades.Disciplina", "Disciplina")
                        .WithMany("Atividades")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unihub.Dominio.Entidades.Nota", "Nota")
                        .WithOne("Atividade")
                        .HasForeignKey("Unihub.Dominio.Entidades.Atividade", "NotaId");

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");

                    b.Navigation("Nota");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.AulasNaSemana", b =>
                {
                    b.HasOne("Unihub.Dominio.Entidades.Disciplina", "Disciplina")
                        .WithMany("AulasNaSemanas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unihub.Dominio.Entidades.HorarioAula", "HorarioAula")
                        .WithMany("AulasNaSemanas")
                        .HasForeignKey("HorarioAulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("HorarioAula");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Disciplina", b =>
                {
                    b.HasOne("Unihub.Dominio.Entidades.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Falta", b =>
                {
                    b.HasOne("Unihub.Dominio.Entidades.Aluno", "Aluno")
                        .WithMany("Faltas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unihub.Dominio.Entidades.Disciplina", "Disciplina")
                        .WithMany("Faltas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unihub.Dominio.Entidades.HorarioAula", "HorarioAula")
                        .WithMany("Faltas")
                        .HasForeignKey("HorarioAulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");

                    b.Navigation("HorarioAula");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Aluno", b =>
                {
                    b.Navigation("AlunosDisciplinas");

                    b.Navigation("Atividades");

                    b.Navigation("Faltas");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Disciplina", b =>
                {
                    b.Navigation("AlunosDisciplinas");

                    b.Navigation("Atividades");

                    b.Navigation("AulasNaSemanas");

                    b.Navigation("Faltas");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.HorarioAula", b =>
                {
                    b.Navigation("AulasNaSemanas");

                    b.Navigation("Faltas");
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Nota", b =>
                {
                    b.Navigation("Atividade")
                        .IsRequired();
                });

            modelBuilder.Entity("Unihub.Dominio.Entidades.Professor", b =>
                {
                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
