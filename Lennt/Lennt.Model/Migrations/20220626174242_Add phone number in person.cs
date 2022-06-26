using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lennt.Model.Migrations
{
    public partial class Addphonenumberinperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "Vacancies");

            migrationBuilder.AddColumn<long>(
                name: "CreatePersonId",
                table: "Vacancies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "VacancyPersons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    VacancyId = table.Column<long>(type: "bigint", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyPersons_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyPersons_PersonId",
                table: "VacancyPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyPersons_VacancyId",
                table: "VacancyPersons",
                column: "VacancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyPersons");

            migrationBuilder.DropColumn(
                name: "CreatePersonId",
                table: "Vacancies");

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "Vacancies",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
