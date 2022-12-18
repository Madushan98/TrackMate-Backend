using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseService.Migrations
{
    public partial class Organization_init_data1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "EmployeesWithPasses", "IsApproved", "OrganizationName", "OrganizationType" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111112"), 0, true, "Test1 Organization", "School" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), 0, false, "Test2 Organization", "University" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), 0, true, "Test3 Organization", "Garment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));
        }
    }
}
