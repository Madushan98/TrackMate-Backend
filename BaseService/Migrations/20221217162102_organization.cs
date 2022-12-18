using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseService.Migrations
{
    public partial class organization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: false),
                    OrganizationType = table.Column<string>(type: "text", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    EmployeesWithPasses = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineType = table.Column<string>(type: "text", nullable: false),
                    VaccineDoseNumber = table.Column<int>(type: "integer", nullable: false),
                    vaccinatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vaccinatedPlace = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDatas", x => x.Id);
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
                    IsVertified = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    OrganizationDaoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationDaoId",
                        column: x => x.OrganizationDaoId,
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
                name: "VaccinationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinationDataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationUsers_VaccinationDatas_VaccinationDataId",
                        column: x => x.VaccinationDataId,
                        principalTable: "VaccinationDatas",
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
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "DeviceId", "District", "EmergencyContactNumber", "FullName", "Gender", "IsVertified", "Iv", "JoinedDate", "Key", "Location", "NationalId", "OrganizationDaoId", "Password", "PrimaryContactNumber", "Town", "UserType" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, null, null, "Admin", null, true, "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "982351123V", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "Admin" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), null, null, null, null, null, "User", null, true, "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "988888888", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "User" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), null, null, null, null, null, "Scanner", null, true, "Qn0j+NTJFfCQ2Hw6WdjXqA==", null, "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=", null, "988888188", null, "KcsI7gpDcpIWTwuCQUIvDA==", null, null, "Scanner" }
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
                name: "IX_Users_OrganizationDaoId",
                table: "Users",
                column: "OrganizationDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationUsers_UserId",
                table: "VaccinationUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationUsers_VaccinationDataId",
                table: "VaccinationUsers",
                column: "VaccinationDataId",
                unique: true);
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
                name: "VaccinationUsers");

            migrationBuilder.DropTable(
                name: "Passes");

            migrationBuilder.DropTable(
                name: "VaccinationDatas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
