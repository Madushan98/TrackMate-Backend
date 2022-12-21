using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Iv = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    OrganizationType = table.Column<string>(type: "text", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    EmployeesWithPasses = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NationalId = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Iv = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PrimaryContactNumber = table.Column<string>(type: "text", nullable: true),
                    EmergencyContactNumber = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Town = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    IsVertified = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneratedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PassCategory = table.Column<string>(type: "text", nullable: false),
                    From = table.Column<string>(type: "text", nullable: false),
                    To = table.Column<string>(type: "text", nullable: false),
                    IsReoccurring = table.Column<bool>(type: "boolean", nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    NationalId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineType = table.Column<string>(type: "text", nullable: false),
                    VaccineDoseNumber = table.Column<int>(type: "integer", nullable: false),
                    vaccinatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vaccinatedPlace = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationDatas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassDataMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PassDaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassDataMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassDataMaps_Passes_PassDaoId",
                        column: x => x.PassDaoId,
                        principalTable: "Passes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    LogTime = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    ScannerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassLogs_Passes_PassId",
                        column: x => x.PassId,
                        principalTable: "Passes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassLogs_Users_ScannerId",
                        column: x => x.ScannerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPassDao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPassDao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPassDao_Passes_PassId",
                        column: x => x.PassId,
                        principalTable: "Passes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPassDao_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address", "City", "EmailAddress", "EmployeesWithPasses", "IsApproved", "Iv", "Key", "MobileNumber", "OrganizationName", "OrganizationType", "Password", "PostalCode", "State", "UserType" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, null, "Test@gmail.com", 0, true, "Qn0j+NTJFfCQ2Hw6WdjXqA==", "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", "07555555555", "Test Organization", "Health", "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "Organization" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), null, null, "Test1@gmail.com", 0, true, "Qn0j+NTJFfCQ2Hw6WdjXqA==", "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", "07666666666", "Test1 Organization", "School", "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "Organization" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), null, null, "Test2@gmail.com", 0, false, "Qn0j+NTJFfCQ2Hw6WdjXqA==", "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", "07777777777", "Test2 Organization", "University", "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "Organization" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), null, null, "Test3@gmail.com", 0, true, "Qn0j+NTJFfCQ2Hw6WdjXqA==", "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", "07612345678", "Test3 Organization", "Garment", "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "Organization" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "DeviceId", "District", "EmergencyContactNumber", "FullName", "Gender", "IsVertified", "Iv", "JoinedDate", "Key", "Location", "NationalId", "OrganizationId", "Password", "PrimaryContactNumber", "Town", "UserType" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, null, null, "Admin", null, "Verified", "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "982351123V", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "Admin" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), null, null, null, null, null, "User", null, "Verified", "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "988888888", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "User" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), null, null, null, null, null, "Scanner", null, "Verified", "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "988888188", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "Scanner" },
                    { new Guid("11111111-1111-1111-1111-111111112213"), null, null, null, null, null, "Achila Sandeep", null, "Pending", "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "9843211234", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "User" },
                    { new Guid("11111111-1111-1111-1111-121111112112"), null, null, null, null, null, "Chathura Nuwan", null, "NotVerified", "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "9812345678", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassDataMaps_PassDaoId",
                table: "PassDataMaps",
                column: "PassDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Passes_UserId",
                table: "Passes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PassLogs_PassId",
                table: "PassLogs",
                column: "PassId");

            migrationBuilder.CreateIndex(
                name: "IX_PassLogs_ScannerId",
                table: "PassLogs",
                column: "ScannerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassLogs_UserId",
                table: "PassLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPassDao_PassId",
                table: "UserPassDao",
                column: "PassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPassDao_UserId",
                table: "UserPassDao",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalId",
                table: "Users",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDatas_UserId",
                table: "VaccinationDatas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassDataMaps");

            migrationBuilder.DropTable(
                name: "PassLogs");

            migrationBuilder.DropTable(
                name: "UserPassDao");

            migrationBuilder.DropTable(
                name: "VaccinationDatas");

            migrationBuilder.DropTable(
                name: "Passes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
