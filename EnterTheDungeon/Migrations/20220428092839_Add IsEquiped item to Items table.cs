using Microsoft.EntityFrameworkCore.Migrations;

namespace EnterTheDungeon.Migrations
{
    public partial class AddIsEquipeditemtoItemstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Constitution",
                table: "Characters",
                newName: "MaxHealth");

            migrationBuilder.AddColumn<bool>(
                name: "IsEquiped",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Armor",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentHealth",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEquiped",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Armor",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CurrentHealth",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "MaxHealth",
                table: "Characters",
                newName: "Constitution");
        }
    }
}
