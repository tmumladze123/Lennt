using Microsoft.EntityFrameworkCore.Migrations;

namespace Lennt.Model.Migrations
{
    public partial class CategoryinPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReviewCount",
                table: "Persons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Persons",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CategoryId",
                table: "Persons",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Categories_CategoryId",
                table: "Persons",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Categories_CategoryId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CategoryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewCount",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
