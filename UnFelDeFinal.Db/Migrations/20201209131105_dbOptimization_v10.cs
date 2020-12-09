using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class dbOptimization_v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo",
                column: "AddressPersonId",
                unique: true,
                filter: "[AddressPersonId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo",
                column: "AddressPersonId");
        }
    }
}
