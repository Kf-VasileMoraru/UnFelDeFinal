using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnFelDeFinal.Db.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityHalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    BanckAccount = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityHalls", x => x.Id);
                    table.CheckConstraint("CK_CityHall_Name", "Name Like '%___%'");
                });

            migrationBuilder.CreateTable(
                name: "Eservices",
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
                    table.PrimaryKey("PK_Eservices", x => x.Id);
                    table.UniqueConstraint("AK_Eservices_TreasureAccount", x => x.TreasureAccount);
                });

            migrationBuilder.CreateTable(
                name: "PayerInfo",
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
                    table.PrimaryKey("PK_PayerInfo", x => x.Id);
                    table.CheckConstraint("CK_PayerInfo_Amount", "Amount Like '%[0-9]%'");
                    table.CheckConstraint("CK_PayerInfo_Idnx", "Idnx Like '[012]____________'");
                    table.CheckConstraint("CK_PayerInfo_PayerName", "PayerName Like '%_____%'");
                });

            migrationBuilder.CreateTable(
                name: "Ibans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "char(24)", nullable: false),
                    ServiceId = table.Column<int>(nullable: true),
                    CityHallId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ibans", x => x.Id);
                    table.CheckConstraint("CQ_Iban_Name", "Name Like 'MD______________________'");
                    table.ForeignKey(
                        name: "FK_Ibans_CityHalls_CityHallId",
                        column: x => x.CityHallId,
                        principalTable: "CityHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ibans_Eservices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Eservices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPayed = table.Column<bool>(nullable: false, defaultValue: false),
                    IsPayedDataTime = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    ServiceId = table.Column<int>(nullable: true),
                    CityHallId = table.Column<int>(nullable: true),
                    PayerInfoId = table.Column<int>(nullable: true),
                    IbanId = table.Column<int>(nullable: false)
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
                table: "CityHalls",
                columns: new[] { "Id", "BanckAccount", "Name" },
                values: new object[,]
                {
                    { 1, "BanckAccount1", "Ciorescu" },
                    { 2, "BanckAccount2", "Bacioi" },
                    { 3, "BanckAccount3", "Bubuieci" },
                    { 4, "BanckAccount4", "Budesti" }
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

            migrationBuilder.InsertData(
                table: "Ibans",
                columns: new[] { "Id", "CityHallId", "Name", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, "MD_____________________1", 1 },
                    { 2, 2, "MD_____________________2", 1 },
                    { 3, 3, "MD_____________________3", 1 },
                    { 4, 4, "MD_____________________4", 1 },
                    { 5, 1, "MD_____________________5", 2 },
                    { 6, 2, "MD_____________________6", 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiceList",
                columns: new[] { "Id", "CityHallId", "IbanId", "IsPayedDataTime", "PayerInfoId", "ServiceId" },
                values: new object[] { 1, 1, 1, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "ServiceList",
                columns: new[] { "Id", "CityHallId", "IbanId", "IsPayedDataTime", "PayerInfoId", "ServiceId" },
                values: new object[] { 2, 2, 2, null, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Ibans_CityHallId",
                table: "Ibans",
                column: "CityHallId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceList");

            migrationBuilder.DropTable(
                name: "Ibans");

            migrationBuilder.DropTable(
                name: "PayerInfo");

            migrationBuilder.DropTable(
                name: "CityHalls");

            migrationBuilder.DropTable(
                name: "Eservices");
        }
    }
}
