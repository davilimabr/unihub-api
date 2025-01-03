using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unihub.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class Adicao_Matricula_Aluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Aluno",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Aluno");
        }
    }
}
