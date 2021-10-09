using Microsoft.EntityFrameworkCore.Migrations;

namespace Pride_.Migrations
{
    public partial class _0810 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Especialidade",
                table: "ProfessionalType",
                newName: "Speciality");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "ProfessionalType",
                newName: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Speciality",
                table: "ProfessionalType",
                newName: "Especialidade");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "ProfessionalType",
                newName: "Categoria");
        }
    }
}
