using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class dbOptimization_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_CityHalls_CityHallId",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_ElectronicService_ElectronicServiceId",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                table: "BillingDetails");

            migrationBuilder.DropTable(
                name: "ElectronicServicePaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_BillingDetails_ElectronicServicePaymentInfoId",
                table: "BillingDetails");

            migrationBuilder.DropColumn(
                name: "ElectronicServicePaymentInfoId",
                table: "BillingDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ElectronicServiceId",
                table: "BillingDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityHallId",
                table: "BillingDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_CityHalls_CityHallId",
                table: "BillingDetails",
                column: "CityHallId",
                principalTable: "CityHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_ElectronicService_ElectronicServiceId",
                table: "BillingDetails",
                column: "ElectronicServiceId",
                principalTable: "ElectronicService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_CityHalls_CityHallId",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetails_ElectronicService_ElectronicServiceId",
                table: "BillingDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ElectronicServiceId",
                table: "BillingDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CityHallId",
                table: "BillingDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ElectronicServicePaymentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressPersonId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataTime = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()"),
                    Idnx = table.Column<string>(type: "char(13)", nullable: false),
                    PayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PayerType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicServicePaymentInfo", x => x.Id);
                    table.CheckConstraint("CK_PayerInfo_Amount", "Amount Like '%[0-9]%'");
                    table.CheckConstraint("CK_PayerInfo_Idnx", "Idnx Like '[012]____________'");
                    table.CheckConstraint("CK_PayerInfo_PayerName", "PayerName Like '%_____%'");
                    table.ForeignKey(
                        name: "FK_ElectronicServicePaymentInfo_AddressPeople_AddressPersonId",
                        column: x => x.AddressPersonId,
                        principalTable: "AddressPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ElectronicServicePaymentInfo",
                columns: new[] { "Id", "AddressPersonId", "Amount", "Comment", "Idnx", "PayerName", "PayerType" },
                values: new object[] { 1, null, 20.2m, null, "0123456789012", "payer name 1", 0 });

            migrationBuilder.InsertData(
                table: "ElectronicServicePaymentInfo",
                columns: new[] { "Id", "AddressPersonId", "Amount", "Comment", "Idnx", "PayerName", "PayerType" },
                values: new object[] { 2, null, 10.2m, null, "0123456789013", "payer name 2", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                column: "ElectronicServicePaymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo",
                column: "AddressPersonId",
                unique: true,
                filter: "[AddressPersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_CityHalls_CityHallId",
                table: "BillingDetails",
                column: "CityHallId",
                principalTable: "CityHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_ElectronicService_ElectronicServiceId",
                table: "BillingDetails",
                column: "ElectronicServiceId",
                principalTable: "ElectronicService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
