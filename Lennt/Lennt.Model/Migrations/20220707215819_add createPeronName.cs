using Microsoft.EntityFrameworkCore.Migrations;

namespace Lennt.Model.Migrations
{
    public partial class addcreatePeronName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Vacancies",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<string>(
                name: "CreatePersonName",
                table: "Vacancies",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatePersonName",
                table: "Vacancies");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Vacancies",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);
        }
    }
}
