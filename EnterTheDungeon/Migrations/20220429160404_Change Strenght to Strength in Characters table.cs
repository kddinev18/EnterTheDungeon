using Microsoft.EntityFrameworkCore.Migrations;

namespace EnterTheDungeon.Migrations
{
    public partial class ChangeStrenghttoStrengthinCharacterstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Constitution",
                table: "Items",
                newName: "Health");

            migrationBuilder.RenameColumn(
                name: "Strenght",
                table: "Characters",
                newName: "Strength");

            migrationBuilder.AddColumn<int>(
                name: "Armor",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Armor",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Health",
                table: "Items",
                newName: "Constitution");

            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "Characters",
                newName: "Strenght");
        }
    }
}
