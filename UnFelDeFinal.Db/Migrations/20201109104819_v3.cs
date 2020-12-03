using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressCityHallId",
                table: "CityHalls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressCityHallId1",
                table: "CityHalls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressCityHallId2",
                table: "CityHalls",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressCityHalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    PostalColde = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCityHalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressPeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    PostalColde = table.Column<string>(nullable: true),
                    ElectronicServicePaymentInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressPeople_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                        column: x => x.ElectronicServicePaymentInfoId,
                        principalTable: "ElectronicServicePaymentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCityHalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactData = table.Column<string>(nullable: true),
                    CityHallId = table.Column<int>(nullable: true),
                    ContactTypeId0 = table.Column<int>(nullable: true),
                    ContactTypeId1 = table.Column<int>(nullable: true),
                    ContactTypeId2 = table.Column<int>(nullable: true),
                    ContactTypeId3 = table.Column<int>(nullable: true),
                    ContactTypeId4 = table.Column<int>(nullable: true),
                    ContactTypeId5 = table.Column<int>(nullable: true),
                    ContactTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCityHalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactCityHalls_CityHalls_CityHallId",
                        column: x => x.CityHallId,
                        principalTable: "CityHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactCityHalls_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactPeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactData = table.Column<string>(nullable: true),
                    ContactTypeId0 = table.Column<int>(nullable: true),
                    ContactTypeId1 = table.Column<int>(nullable: true),
                    ElectronicServicePaymentInfoId = table.Column<int>(nullable: true),
                    ContactTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPeople_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactPeople_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                        column: x => x.ElectronicServicePaymentInfoId,
                        principalTable: "ElectronicServicePaymentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityHalls_AddressCityHallId",
                table: "CityHalls",
                column: "AddressCityHallId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressPeople_ElectronicServicePaymentInfoId",
                table: "AddressPeople",
                column: "ElectronicServicePaymentInfoId",
                unique: true,
                filter: "[ElectronicServicePaymentInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactCityHalls_CityHallId",
                table: "ContactCityHalls",
                column: "CityHallId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactCityHalls_ContactTypeId",
                table: "ContactCityHalls",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPeople_ContactTypeId",
                table: "ContactPeople",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPeople_ElectronicServicePaymentInfoId",
                table: "ContactPeople",
                column: "ElectronicServicePaymentInfoId",
                unique: true,
                filter: "[ElectronicServicePaymentInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CityHalls_AddressCityHalls_AddressCityHallId",
                table: "CityHalls",
                column: "AddressCityHallId",
                principalTable: "AddressCityHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityHalls_AddressCityHalls_AddressCityHallId",
                table: "CityHalls");

            migrationBuilder.DropTable(
                name: "AddressCityHalls");

            migrationBuilder.DropTable(
                name: "AddressPeople");

            migrationBuilder.DropTable(
                name: "ContactCityHalls");

            migrationBuilder.DropTable(
                name: "ContactPeople");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropIndex(
                name: "IX_CityHalls_AddressCityHallId",
                table: "CityHalls");

            migrationBuilder.DropColumn(
                name: "AddressCityHallId",
                table: "CityHalls");

            migrationBuilder.DropColumn(
                name: "AddressCityHallId1",
                table: "CityHalls");

            migrationBuilder.DropColumn(
                name: "AddressCityHallId2",
                table: "CityHalls");
        }
    }
}
