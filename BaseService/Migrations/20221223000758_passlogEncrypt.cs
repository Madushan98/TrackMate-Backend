using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseService.Migrations
{
    public partial class passlogEncrypt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassLogEncrypts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false),
                    LogTime = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    ScannerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserNatId = table.Column<string>(type: "text", nullable: false),
                    PassId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassLogEncrypts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassLogEncrypts_Passes_PassId",
                        column: x => x.PassId,
                        principalTable: "Passes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassLogEncrypts_Users_ScannerId",
                        column: x => x.ScannerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassLogEncrypts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassLogEncrypts_PassId",
                table: "PassLogEncrypts",
                column: "PassId");

            migrationBuilder.CreateIndex(
                name: "IX_PassLogEncrypts_ScannerId",
                table: "PassLogEncrypts",
                column: "ScannerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassLogEncrypts_UserId",
                table: "PassLogEncrypts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassLogEncrypts");
        }
    }
}
