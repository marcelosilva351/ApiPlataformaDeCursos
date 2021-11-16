using Microsoft.EntityFrameworkCore.Migrations;

namespace Cursos.Infra.Migrations
{
    public partial class AjustandoNomeTabelaReferencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Cursos_IdCurso",
                table: "MyProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Professor_IdProfessor",
                table: "MyProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "ProfessorCursos");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_IdProfessor",
                table: "ProfessorCursos",
                newName: "IX_ProfessorCursos_IdProfessor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorCursos",
                table: "ProfessorCursos",
                columns: new[] { "IdCurso", "IdProfessor" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorCursos_Cursos_IdCurso",
                table: "ProfessorCursos",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorCursos_Professor_IdProfessor",
                table: "ProfessorCursos",
                column: "IdProfessor",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorCursos_Cursos_IdCurso",
                table: "ProfessorCursos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorCursos_Professor_IdProfessor",
                table: "ProfessorCursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorCursos",
                table: "ProfessorCursos");

            migrationBuilder.RenameTable(
                name: "ProfessorCursos",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorCursos_IdProfessor",
                table: "MyProperty",
                newName: "IX_MyProperty_IdProfessor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                columns: new[] { "IdCurso", "IdProfessor" });

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Cursos_IdCurso",
                table: "MyProperty",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Professor_IdProfessor",
                table: "MyProperty",
                column: "IdProfessor",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
