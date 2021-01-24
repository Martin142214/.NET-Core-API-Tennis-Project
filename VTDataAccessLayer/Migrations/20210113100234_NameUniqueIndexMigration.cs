using Microsoft.EntityFrameworkCore.Migrations;

namespace VTDataAccessLayer.Migrations
{
    public partial class NameUniqueIndexMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Player_AuthenticationCode",
                table: "Player");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Player",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthenticationCode",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_Name",
                table: "Player",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Player_Name",
                table: "Player");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthenticationCode",
                table: "Player",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_AuthenticationCode",
                table: "Player",
                column: "AuthenticationCode",
                unique: true,
                filter: "[AuthenticationCode] IS NOT NULL");
        }
    }
}
