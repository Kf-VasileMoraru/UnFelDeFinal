using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class dbOptimization_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ElectronicServicePaymentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayerName = table.Column<string>(maxLength: 100, nullable: false),
                    Idnx = table.Column<string>(type: "char(13)", nullable: false),
                    PayerType = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    DataTime = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()"),
                    Comment = table.Column<string>(nullable: true),
                    AddressPersonId = table.Column<int>(nullable: true)
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
                column: "AddressPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetails_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                column: "ElectronicServicePaymentInfoId",
                principalTable: "ElectronicServicePaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
