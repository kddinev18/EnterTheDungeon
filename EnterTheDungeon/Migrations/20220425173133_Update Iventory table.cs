using Microsoft.EntityFrameworkCore.Migrations;

namespace EnterTheDungeon.Migrations
{
    public partial class UpdateIventorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCampaign_Campaign_CampaignId",
                table: "CharacterCampaign");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCampaign_Characters_CharacterId",
                table: "CharacterCampaign");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Inventories_InventoryId1",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_InventoryId1",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterCampaign",
                table: "CharacterCampaign");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryId1",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "CharacterCampaign",
                newName: "CharacterCampaigns");

            migrationBuilder.RenameTable(
                name: "Campaign",
                newName: "Campaigns");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterCampaign_CharacterId",
                table: "CharacterCampaigns",
                newName: "IX_CharacterCampaigns_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterCampaigns",
                table: "CharacterCampaigns",
                columns: new[] { "CampaignId", "CharacterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCampaigns_Campaigns_CampaignId",
                table: "CharacterCampaigns",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCampaigns_Characters_CharacterId",
                table: "CharacterCampaigns",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Inventories_InventoryId",
                table: "Characters",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCampaigns_Campaigns_CampaignId",
                table: "CharacterCampaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCampaigns_Characters_CharacterId",
                table: "CharacterCampaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Inventories_InventoryId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterCampaigns",
                table: "CharacterCampaigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns");

            migrationBuilder.RenameTable(
                name: "CharacterCampaigns",
                newName: "CharacterCampaign");

            migrationBuilder.RenameTable(
                name: "Campaigns",
                newName: "Campaign");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterCampaigns_CharacterId",
                table: "CharacterCampaign",
                newName: "IX_CharacterCampaign_CharacterId");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId1",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterCampaign",
                table: "CharacterCampaign",
                columns: new[] { "CampaignId", "CharacterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InventoryId1",
                table: "Characters",
                column: "InventoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCampaign_Campaign_CampaignId",
                table: "CharacterCampaign",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCampaign_Characters_CharacterId",
                table: "CharacterCampaign",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Inventories_InventoryId1",
                table: "Characters",
                column: "InventoryId1",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
