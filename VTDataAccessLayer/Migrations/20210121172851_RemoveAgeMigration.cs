using Microsoft.EntityFrameworkCore.Migrations;

namespace VTDataAccessLayer.Migrations
{
    public partial class RemoveAgeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Player");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
