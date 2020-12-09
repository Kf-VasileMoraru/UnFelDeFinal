using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class dbOptimization_v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment2",
                table: "ElectronicServicePaymentInfo");

            migrationBuilder.AddColumn<int>(
                name: "AddressPersonId",
                table: "ElectronicServicePaymentInfo",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Comment2",
                table: "ElectronicServicePaymentInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
