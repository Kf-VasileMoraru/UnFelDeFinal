using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class hasAlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ElectronicService_TreasureAccount",
                table: "ElectronicService");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicService_TreasureAccount",
                table: "ElectronicService",
                column: "TreasureAccount",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ElectronicService_TreasureAccount",
                table: "ElectronicService");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ElectronicService_TreasureAccount",
                table: "ElectronicService",
                column: "TreasureAccount");
        }
    }
}
