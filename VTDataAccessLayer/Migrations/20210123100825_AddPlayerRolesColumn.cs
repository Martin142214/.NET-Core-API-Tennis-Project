using Microsoft.EntityFrameworkCore.Migrations;

namespace VTDataAccessLayer.Migrations
{
    public partial class AddPlayerRolesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrRoles",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrRoles",
                table: "Player");
        }
    }
}
