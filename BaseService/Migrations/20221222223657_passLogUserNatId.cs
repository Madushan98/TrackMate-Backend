using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseService.Migrations
{
    public partial class passLogUserNatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNatId",
                table: "PassLogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNatId",
                table: "PassLogs");
        }
    }
}
