using Microsoft.EntityFrameworkCore.Migrations;

namespace InternProj.Db.Migrations
{
    public partial class CityHall_AddField_IsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CityHalls",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CityHalls");
        }
    }
}
