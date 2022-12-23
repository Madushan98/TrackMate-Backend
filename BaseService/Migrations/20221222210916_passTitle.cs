using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseService.Migrations
{
    public partial class passTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassTitle",
                table: "Passes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-121111112112"),
                column: "IsVertified",
                value: "Not Verified");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "DeviceId", "District", "EmergencyContactNumber", "FullName", "Gender", "IsVertified", "Iv", "JoinedDate", "Key", "Location", "NationalId", "OrganizationId", "Password", "PrimaryContactNumber", "Town", "UserType" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111412213"), null, null, null, null, null, "Achila Nuwan", null, "Pending", "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "9843211334", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "User" },
                    { new Guid("11111111-1111-1111-1111-111151112213"), null, null, null, null, null, "Chathura Sandeep", null, "Pending", "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "9842211234", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111412213"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111151112213"));

            migrationBuilder.DropColumn(
                name: "PassTitle",
                table: "Passes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-121111112112"),
                column: "IsVertified",
                value: "NotVerified");
        }
    }
}
