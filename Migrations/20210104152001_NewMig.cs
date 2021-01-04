using Microsoft.EntityFrameworkCore.Migrations;

namespace Korelskiy.WW2Project.Migrations
{
    public partial class NewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionCount",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Weapon",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionCount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Weapon",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Items");
        }
    }
}
