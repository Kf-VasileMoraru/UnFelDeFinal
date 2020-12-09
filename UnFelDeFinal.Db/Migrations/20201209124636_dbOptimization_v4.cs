using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class dbOptimization_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                table: "BillingDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                column: "ElectronicServicePaymentInfoId",
                principalTable: "ElectronicServicePaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                table: "BillingDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                column: "ElectronicServicePaymentInfoId",
                principalTable: "ElectronicServicePaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
