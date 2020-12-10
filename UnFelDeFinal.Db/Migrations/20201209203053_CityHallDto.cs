using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class CityHallDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email3",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Phone3",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "PostalColde",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Web3",
                table: "AddressCityHalls");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CityHalls",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Email0",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone0",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AddressCityHalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Web0",
                table: "AddressCityHalls",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email0",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Phone0",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AddressCityHalls");

            migrationBuilder.DropColumn(
                name: "Web0",
                table: "AddressCityHalls");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CityHalls",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AddColumn<string>(
                name: "Email3",
                table: "AddressCityHalls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone3",
                table: "AddressCityHalls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalColde",
                table: "AddressCityHalls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Web3",
                table: "AddressCityHalls",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
