using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Pride_.Migrations
{
    public partial class professionals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "pacients");

            migrationBuilder.CreateTable(
                name: "ProfessionalType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Categoria = table.Column<string>(type: "text", nullable: true),
                    Especialidade = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Instagram = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Register = table.Column<string>(type: "text", nullable: true),
                    ProfessionalTypeId = table.Column<int>(type: "integer", nullable: true),
                    Speciality = table.Column<string>(type: "text", nullable: true),
                    HealthInsurance = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Email);
                    table.ForeignKey(
                        name: "FK_users_ProfessionalType_ProfessionalTypeId",
                        column: x => x.ProfessionalTypeId,
                        principalTable: "ProfessionalType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_ProfessionalTypeId",
                table: "users",
                column: "ProfessionalTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "ProfessionalType");

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    CRM = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    CPF = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    HealthInsurance = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    SocialMedia = table.Column<string>(type: "text", nullable: true),
                    Speciality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.CRM);
                });

            migrationBuilder.CreateTable(
                name: "pacients",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    SocialMedia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacients", x => x.CPF);
                });
        }
    }
}
