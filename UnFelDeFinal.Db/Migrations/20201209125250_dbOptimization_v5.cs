using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class dbOptimization_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicServicePaymentInfo_AddressPeople_AddressPersonId",
                table: "ElectronicServicePaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo");

            migrationBuilder.DropColumn(
                name: "AddressPersonId",
                table: "ElectronicServicePaymentInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressPersonId",
                table: "ElectronicServicePaymentInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo",
                column: "AddressPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicServicePaymentInfo_AddressPeople_AddressPersonId",
                table: "ElectronicServicePaymentInfo",
                column: "AddressPersonId",
                principalTable: "AddressPeople",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
