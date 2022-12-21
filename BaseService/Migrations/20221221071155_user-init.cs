using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseService.Migrations
{
    public partial class userinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "DeviceId", "District", "EmergencyContactNumber", "FullName", "Gender", "IsVertified", "Iv", "JoinedDate", "Key", "Location", "NationalId", "OrganizationId", "Password", "PrimaryContactNumber", "Town", "UserType" },
                values: new object[] { new Guid("11111111-1111-1111-1111-121111112112"), null, null, null, null, null, "Chathura Nuwan", null, false, "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "9812345678", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-121111112112"));
        }
    }
}
