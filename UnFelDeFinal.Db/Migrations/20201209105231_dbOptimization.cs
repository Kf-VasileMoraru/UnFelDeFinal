using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class dbOptimization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressPeople_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                table: "AddressPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_CityHalls_AddressCityHalls_AddressCityHallId",
                table: "CityHalls");

            migrationBuilder.DropTable(
                name: "ContactCityHalls");

            migrationBuilder.DropTable(
                name: "ContactPeople");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropIndex(
                name: "IX_CityHalls_AddressCityHallId",
                table: "CityHalls");

            migrationBuilder.DropIndex(
                name: "IX_AddressPeople_ElectronicServicePaymentInfoId",
                table: "AddressPeople");

            migrationBuilder.DropColumn(
                name: "AddressCityHallId",
                table: "CityHalls");

            migrationBuilder.DropColumn(
                name: "AddressCityHallId1",
                table: "CityHalls");

            migrationBuilder.DropColumn(
                name: "AddressCityHallId2",
                table: "CityHalls");

            migrationBuilder.DropColumn(
                name: "ElectronicServicePaymentInfoId",
                table: "AddressPeople");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "AddressPeople");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "AddressPeople");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "AddressCityHalls");

            migrationBuilder.AddColumn<int>(
                name: "AddressPersonId",
                table: "ElectronicServicePaymentInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalColde",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetHouseNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetHouseNumber",
                table: "AddressPeople",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityHallId",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email1",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email3",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone3",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetHouseNumber",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Web1",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Web2",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Web3",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo",
                column: "AddressPersonId",
                unique: true,
                filter: "[AddressPersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCityHalls_CityHallId",
                table: "AddressCityHalls",
                column: "CityHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCityHalls_CityHalls_CityHallId",
                table: "AddressCityHalls",
                column: "CityHallId",
                principalTable: "CityHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_AddressCityHalls_CityHalls_CityHallId",
                table: "AddressCityHalls");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicServicePaymentInfo_AddressPeople_AddressPersonId",
                table: "ElectronicServicePaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_ElectronicServicePaymentInfo_AddressPersonId",
                table: "ElectronicServicePaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_AddressCityHalls_CityHallId",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "AddressPersonId",
                table: "ElectronicServicePaymentInfo");

            migrationBuilder.DropColumn(
                name: "PostalColde",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetHouseNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetHouseNumber",
                table: "AddressPeople");

            migrationBuilder.DropColumn(
                name: "CityHallId",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Email1",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Email3",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Phone3",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "StreetHouseNumber",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Web1",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Web2",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Web3",
                table: "AddressCityHalls");

            migrationBuilder.AddColumn<int>(
                name: "AddressCityHallId",
                table: "CityHalls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressCityHallId1",
                table: "CityHalls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressCityHallId2",
                table: "CityHalls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElectronicServicePaymentInfoId",
                table: "AddressPeople",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "AddressPeople",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "AddressPeople",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "AddressCityHalls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "AddressCityHalls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCityHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityHallId = table.Column<int>(type: "int", nullable: true),
                    ContactData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId0 = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId1 = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId2 = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId3 = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId4 = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId5 = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId0 = table.Column<int>(type: "int", nullable: true),
                    ContactTypeId1 = table.Column<int>(type: "int", nullable: true),
                    ElectronicServicePaymentInfoId = table.Column<int>(type: "int", nullable: true)
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
                name: "FK_AddressPeople_ElectronicServicePaymentInfo_ElectronicServicePaymentInfoId",
                table: "AddressPeople",
                column: "ElectronicServicePaymentInfoId",
                principalTable: "ElectronicServicePaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CityHalls_AddressCityHalls_AddressCityHallId",
                table: "CityHalls",
                column: "AddressCityHallId",
                principalTable: "AddressCityHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
