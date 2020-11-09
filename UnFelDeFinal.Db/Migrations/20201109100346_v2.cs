using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnFelDeFinal.Db.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ibans_Eservices_ServiceId",
                table: "Ibans");

            migrationBuilder.DropTable(
                name: "ServiceList");

            migrationBuilder.DropTable(
                name: "PayerInfo");

            migrationBuilder.DropTable(
                name: "Eservices");

            migrationBuilder.DropIndex(
                name: "IX_Ibans_ServiceId",
                table: "Ibans");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Ibans");

            migrationBuilder.AddColumn<int>(
                name: "ElectronicServiceId",
                table: "Ibans",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ElectronicService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Amount = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    TreasureAccount = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicService", x => x.Id);
                    table.UniqueConstraint("AK_ElectronicService_TreasureAccount", x => x.TreasureAccount);
                });

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
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicServicePaymentInfo", x => x.Id);
                    table.CheckConstraint("CK_PayerInfo_Amount", "Amount Like '%[0-9]%'");
                    table.CheckConstraint("CK_PayerInfo_Idnx", "Idnx Like '[012]____________'");
                    table.CheckConstraint("CK_PayerInfo_PayerName", "PayerName Like '%_____%'");
                });

            migrationBuilder.CreateTable(
                name: "BillingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPayed = table.Column<bool>(nullable: false, defaultValue: false),
                    IsPayedDataTime = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    ElectronicServiceId = table.Column<int>(nullable: true),
                    CityHallId = table.Column<int>(nullable: true),
                    ElectronicServicePaymentInfoId = table.Column<int>(nullable: true),
                    IbanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingDetails_CityHalls_CityHallId",
                        column: x => x.CityHallId,
                        principalTable: "CityHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillingDetails_ElectronicService_ElectronicServiceId",
                        column: x => x.ElectronicServiceId,
                        principalTable: "ElectronicService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillingDetails_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                        column: x => x.ElectronicServicePaymentInfoId,
                        principalTable: "ElectronicServicePaymentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillingDetails_Ibans_IbanId",
                        column: x => x.IbanId,
                        principalTable: "Ibans",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ElectronicService",
                columns: new[] { "Id", "Amount", "Name", "TreasureAccount" },
                values: new object[,]
                {
                    { 1, 20.52m, "test 1 service ", "Treasure1" },
                    { 2, 12.22m, "test 2 service ", "Treasure2" },
                    { 3, 22.12m, "test 3 service ", "Treasure3" },
                    { 4, 2.52m, "test 4 service ", "Treasure4" },
                    { 5, 44.42m, "test 5 service ", "Treasure5" }
                });

            migrationBuilder.InsertData(
                table: "ElectronicServicePaymentInfo",
                columns: new[] { "Id", "Amount", "Comment", "Idnx", "PayerName", "PayerType" },
                values: new object[,]
                {
                    { 1, 20.2m, null, "0123456789012", "payer name 1", 0 },
                    { 2, 10.2m, null, "0123456789013", "payer name 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "BillingDetails",
                columns: new[] { "Id", "CityHallId", "ElectronicServiceId", "ElectronicServicePaymentInfoId", "IbanId", "IsPayedDataTime" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, null },
                    { 2, 2, 2, 1, 2, null }
                });

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 1,
                column: "ElectronicServiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 2,
                column: "ElectronicServiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ElectronicServiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 4,
                column: "ElectronicServiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 5,
                column: "ElectronicServiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 6,
                column: "ElectronicServiceId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Ibans_ElectronicServiceId",
                table: "Ibans",
                column: "ElectronicServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_CityHallId",
                table: "BillingDetails",
                column: "CityHallId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_ElectronicServiceId",
                table: "BillingDetails",
                column: "ElectronicServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_ElectronicServicePaymentInfoId",
                table: "BillingDetails",
                column: "ElectronicServicePaymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetails_IbanId",
                table: "BillingDetails",
                column: "IbanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ibans_ElectronicService_ElectronicServiceId",
                table: "Ibans",
                column: "ElectronicServiceId",
                principalTable: "ElectronicService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ibans_ElectronicService_ElectronicServiceId",
                table: "Ibans");

            migrationBuilder.DropTable(
                name: "BillingDetails");

            migrationBuilder.DropTable(
                name: "ElectronicService");

            migrationBuilder.DropTable(
                name: "ElectronicServicePaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_Ibans_ElectronicServiceId",
                table: "Ibans");

            migrationBuilder.DropColumn(
                name: "ElectronicServiceId",
                table: "Ibans");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Ibans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Eservices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TreasureAccount = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eservices", x => x.Id);
                    table.UniqueConstraint("AK_Eservices_TreasureAccount", x => x.TreasureAccount);
                });

            migrationBuilder.CreateTable(
                name: "PayerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataTime = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()"),
                    Idnx = table.Column<string>(type: "char(13)", nullable: false),
                    PayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PayerType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayerInfo", x => x.Id);
                    table.CheckConstraint("CK_PayerInfo_Amount", "Amount Like '%[0-9]%'");
                    table.CheckConstraint("CK_PayerInfo_Idnx", "Idnx Like '[012]____________'");
                    table.CheckConstraint("CK_PayerInfo_PayerName", "PayerName Like '%_____%'");
                });

            migrationBuilder.CreateTable(
                name: "ServiceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityHallId = table.Column<int>(type: "int", nullable: true),
                    IbanId = table.Column<int>(type: "int", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPayedDataTime = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    PayerInfoId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceList_CityHalls_CityHallId",
                        column: x => x.CityHallId,
                        principalTable: "CityHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceList_Ibans_IbanId",
                        column: x => x.IbanId,
                        principalTable: "Ibans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceList_PayerInfo_PayerInfoId",
                        column: x => x.PayerInfoId,
                        principalTable: "PayerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceList_Eservices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Eservices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Eservices",
                columns: new[] { "Id", "Amount", "Name", "TreasureAccount" },
                values: new object[,]
                {
                    { 1, 20.52m, "test 1 service ", "Treasure1" },
                    { 2, 12.22m, "test 2 service ", "Treasure2" },
                    { 3, 22.12m, "test 3 service ", "Treasure3" },
                    { 4, 2.52m, "test 4 service ", "Treasure4" },
                    { 5, 44.42m, "test 5 service ", "Treasure5" }
                });

            migrationBuilder.InsertData(
                table: "PayerInfo",
                columns: new[] { "Id", "Amount", "Comment", "Idnx", "PayerName", "PayerType" },
                values: new object[,]
                {
                    { 1, 20.2m, null, "0123456789012", "payer name 1", 0 },
                    { 2, 10.2m, null, "0123456789013", "payer name 2", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 1,
                column: "ServiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 2,
                column: "ServiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ServiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 4,
                column: "ServiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 5,
                column: "ServiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Ibans",
                keyColumn: "Id",
                keyValue: 6,
                column: "ServiceId",
                value: 2);

            migrationBuilder.InsertData(
                table: "ServiceList",
                columns: new[] { "Id", "CityHallId", "IbanId", "IsPayedDataTime", "PayerInfoId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1, null, 1, 1 },
                    { 2, 2, 2, null, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ibans_ServiceId",
                table: "Ibans",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceList_CityHallId",
                table: "ServiceList",
                column: "CityHallId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceList_IbanId",
                table: "ServiceList",
                column: "IbanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceList_PayerInfoId",
                table: "ServiceList",
                column: "PayerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceList_ServiceId",
                table: "ServiceList",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ibans_Eservices_ServiceId",
                table: "Ibans",
                column: "ServiceId",
                principalTable: "Eservices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
