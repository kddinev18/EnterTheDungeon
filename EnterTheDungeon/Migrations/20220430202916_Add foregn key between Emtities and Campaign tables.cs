using Microsoft.EntityFrameworkCore.Migrations;

namespace EnterTheDungeon.Migrations
{
    public partial class AddforegnkeybetweenEmtitiesandCampaigntables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Entities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entities_CampaignId",
                table: "Entities",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Campaigns_CampaignId",
                table: "Entities",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Campaigns_CampaignId",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_CampaignId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Entities");
        }
    }
}
