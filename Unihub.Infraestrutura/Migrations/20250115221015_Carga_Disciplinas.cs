using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unihub.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class Carga_Disciplinas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO `unihub`.`disciplina`
                (`Id`,
                 `Nome`,
                 `Codigo`,
                 `Descricao`,
                 `Sala`,
                 `TotalHoras`,
                 `Professor`,
                 `Periodo`,
                 `Obrigatoria`)
                VALUES
                (1, 'Fundamentos de Sistemas de Informação', 'TIN0206', 'Descrição genérica', 'LAB1', 60, 'Professor(a) Genérico(a)', 1, true),
                (2, 'Fundamentos de Cálculo', 'TMT0043', 'Descrição genérica', 'LAB2', 60, 'Professor(a) Genérico(a)', 1, true),
                (3, 'Arquitetura de Computadores', 'TIN0235', 'Descrição genérica', 'LAB3', 60, 'Professor(a) Genérico(a)', 1, true),
                (4, 'Algoritmos e Programação', 'TIN0222', 'Descrição genérica', '511', 60, 'Professor(a) Genérico(a)', 1, true),
                (5, 'Projeto Integrador I', 'TIN0209', 'Descrição genérica', '512', 60, 'Professor(a) Genérico(a)', 2, true),
                (6, 'Álgebra Linear', 'TMT0044', 'Descrição genérica', '513', 60, 'Professor(a) Genérico(a)', 2, true),
                (7, 'Fundamentos de Gestão Organizacional', 'TIN0218', 'Descrição genérica', '514', 60, 'Professor(a) Genérico(a)', 2, true),
                (8, 'Cálculo Diferencial e Integral I', 'TMT0045', 'Descrição genérica', '515', 60, 'Professor(a) Genérico(a)', 2, true),
                (9, 'Introdução à Lógica Computacional', 'TIN0223', 'Descrição genérica', 'LAB1', 60, 'Professor(a) Genérico(a)', 2, true),
                (10, 'Técnicas de Programação', 'TIN0224', 'Descrição genérica', 'LAB2', 60, 'Professor(a) Genérico(a)', 2, true),
                (11, 'Modelagem da Informação', 'TIN0232', 'Descrição genérica', 'LAB3', 60, 'Professor(a) Genérico(a)', 3, true),
                (12, 'Cálculo Diferencial e Integral II', 'TMT0046', 'Descrição genérica', '511', 60, 'Professor(a) Genérico(a)', 3, true),
                (13, 'Estruturas de Dados', 'TIN0225', 'Descrição genérica', '512', 60, 'Professor(a) Genérico(a)', 3, true),
                (14, 'Estruturas Discretas com Algoritmos', 'TIN0257', 'Descrição genérica', '513', 60, 'Professor(a) Genérico(a)', 0, false),
                (15, 'Probabilidade', 'TMQ0007', 'Descrição genérica', '514', 60, 'Professor(a) Genérico(a)', 4, true),
                (16, 'Sistemas Operacionais', 'TIN0236', 'Descrição genérica', '515', 60, 'Professor(a) Genérico(a)', 3, true),
                (17, 'Análise e Projeto de Sistemas', 'TIN0228', 'Descrição genérica', 'LAB1', 60, 'Professor(a) Genérico(a)', 3, true),
                (18, 'Estatística', 'TMQ0008', 'Descrição genérica', 'LAB2', 60, 'Professor(a) Genérico(a)', 5, true),
                (19, 'Estruturas de Dados Avançadas', 'TIN0256', 'Descrição genérica', 'LAB3', 60, 'Professor(a) Genérico(a)', 0, false),
                (20, 'Interação Humano-Computador ', 'TIN0208', 'Descrição genérica', '511', 60, 'Professor(a) Genérico(a)', 1, true),
                (21, 'Linguagens e Paradigmas de Programação', 'TIN0226', 'Descrição genérica', '512', 60, 'Professor(a) Genérico(a)', 3, true),
                (22, 'Redes de Computadores', 'TIN0237', 'Descrição genérica', '513', 60, 'Professor(a) Genérico(a)', 4, true),
                (23, 'Projeto e Análise de Algoritmos', 'TIN0227', 'Descrição genérica', '514', 60, 'Professor(a) Genérico(a)', 4, true),
                (24, 'Armazenamento e Gestão de Dados', 'TIN0233', 'Descrição genérica', '515', 60, 'Professor(a) Genérico(a)', 4, true),
                (25, 'Empreendedorismo e Inovação', 'TIN0221', 'Descrição genérica', 'LAB1', 60, 'Professor(a) Genérico(a)', 6, true),
                (26, 'Engenharia de Software I', 'TIN0229', 'Descrição genérica', 'LAB2', 60, 'Professor(a) Genérico(a)', 4, true),
                (27, 'Redes Móveis e Computação Ubíqua', 'TIN0301', 'Descrição genérica', 'LAB3', 60, 'Professor(a) Genérico(a)', 0, false),
                (28, 'Engenharia de Software II', 'TIN0230', 'Descrição genérica', '511', 60, 'Professor(a) Genérico(a)', 5, true),
                (29, 'Projeto Integrador II', 'TIN0210', 'Descrição genérica', '512', 60, 'Professor(a) Genérico(a)', 4, true),
                (30, 'Tópicos em Processos de Software', 'TIN0284', 'Descrição genérica', '513', 60, 'Professor(a) Genérico(a)', 0, false),
                (31, 'Gerência de Projetos', 'TIN0231', 'Descrição genérica', '514', 60, 'Professor(a) Genérico(a)', 5, true),
                (32, 'Ciência de Dados', 'TIN0234', 'Descrição genérica', '515', 60, 'Professor(a) Genérico(a)', 6, true),
                (33, 'Gestão de Processos de Negócios ', 'TIN0219', 'Descrição genérica', 'LAB1', 60, 'Professor(a) Genérico(a)', 2, true),
                (34, 'Governança de Tecnologia da Informação', 'TIN0220', 'Descrição genérica', 'LAB2', 60, 'Professor(a) Genérico(a)', 5, true),
                (35, 'Informação e Sociedade ', 'TIN0207', 'Descrição genérica', 'LAB3', 60, 'Professor(a) Genérico(a)', 1, true),
                (36, 'Metodologia Científica e Tecnológica', 'TIN0211', 'Descrição genérica', '511', 60, 'Professor(a) Genérico(a)', 5, true),
                (37, 'Atividades de Extensão I', 'TIN0306', 'Descrição genérica', '512', 60, 'Professor(a) Genérico(a)', 0, false),
                (38, 'Atividades de Extensão II', 'TIN0307', 'Descrição genérica', '513', 60, 'Professor(a) Genérico(a)', 0, false),
                (39, 'Projeto de Graduação I', 'TIN0308', 'Descrição genérica', '514', 60, 'Professor(a) Genérico(a)', 0, false),
                (40, 'Projeto de Graduação II', 'TIN0309', 'Descrição genérica', '515', 60, 'Professor(a) Genérico(a)', 0, false),
                (41, 'Acessibilidade', 'TIN0238', 'Descrição genérica', 'LAB1', 60, 'Professor(a) Genérico(a)', 0, false),
                (42, 'Ambiente Operacional UNIX', 'TIN0150', 'Descrição genérica', 'LAB2', 60, 'Professor(a) Genérico(a)', 0, false),
                (43, 'Aprendizagem Profunda', 'TIN0255', 'Descrição genérica', 'LAB3', 60, 'Professor(a) Genérico(a)', 0, false),
                (44, 'Automação', 'TIN0297', 'Descrição genérica', '511', 60, 'Professor(a) Genérico(a)', 0, false),
                (45, 'Ciência de Redes', 'TIN0240', 'Descrição genérica', '512', 60, 'Professor(a) Genérico(a)', 0, false),
                (46, 'Fundamentos de Representação de Conhecimento e Raciocínio', 'TIN0147', 'Descrição genérica', '513', 60, 'Professor(a) Genérico(a)', 0, false),
                (47, 'Heurísticas Inteligentes: Técnicas e Aplicações', 'TIN0260', 'Descrição genérica', '514', 60, 'Professor(a) Genérico(a)', 0, false),
                (48, 'Introdução à Inteligência Artificial', 'TIN0261', 'Descrição genérica', '515', 60, 'Professor(a) Genérico(a)', 0, false),
                (49, 'Projeto de Aplicações com Dados Abertos', 'TIN0291', 'Descrição genérica', 'LAB1', 60, 'Professor(a) Genérico(a)', 0, false),
                (50, 'Projeto de Jogos Digitais', 'TIN0274', 'Descrição genérica', 'LAB2', 60, 'Professor(a) Genérico(a)', 0, false),
                (51, 'Técnicas de Programação Avançada', 'TIN0265', 'Descrição genérica', 'LAB3', 60, 'Professor(a) Genérico(a)', 0, false),
                (52, 'Tópicos em Qualidade de Software', 'TIN0286', 'Descrição genérica', '511', 60, 'Professor(a) Genérico(a)', 0, false)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
