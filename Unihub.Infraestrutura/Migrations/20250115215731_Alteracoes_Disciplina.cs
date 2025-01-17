using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unihub.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class Alteracoes_Disciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Falta_HorarioAula_HorarioAulaId",
                table: "Falta");

            migrationBuilder.DropTable(
                name: "AulasNaSemana");

            migrationBuilder.DropTable(
                name: "HorarioAula");

            migrationBuilder.DropIndex(
                name: "IX_Falta_HorarioAulaId",
                table: "Falta");

            migrationBuilder.RenameColumn(
                name: "HorarioAulaId",
                table: "Falta",
                newName: "Horas");

            migrationBuilder.AddColumn<bool>(
                name: "Obrigatoria",
                table: "Disciplina",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Periodo",
                table: "Disciplina",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obrigatoria",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Disciplina");

            migrationBuilder.RenameColumn(
                name: "Horas",
                table: "Falta",
                newName: "HorarioAulaId");

            migrationBuilder.CreateTable(
                name: "HorarioAula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<int>(type: "int", nullable: false),
                    HoraTermino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioAula", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AulasNaSemana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    HorarioAulaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasNaSemana", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AulasNaSemana_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AulasNaSemana_HorarioAula_HorarioAulaId",
                        column: x => x.HorarioAulaId,
                        principalTable: "HorarioAula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Falta_HorarioAulaId",
                table: "Falta",
                column: "HorarioAulaId");

            migrationBuilder.CreateIndex(
                name: "IX_AulasNaSemana_DisciplinaId",
                table: "AulasNaSemana",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AulasNaSemana_HorarioAulaId",
                table: "AulasNaSemana",
                column: "HorarioAulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Falta_HorarioAula_HorarioAulaId",
                table: "Falta",
                column: "HorarioAulaId",
                principalTable: "HorarioAula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
