using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrueColoursAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrueSyncLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueSyncLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrueTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrueSyncLogDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<int>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    ColourType = table.Column<string>(nullable: true),
                    SyncLogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueSyncLogDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrueSyncLogDetails_TrueSyncLogs_SyncLogId",
                        column: x => x.SyncLogId,
                        principalTable: "TrueSyncLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrueColours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Red = table.Column<int>(nullable: false),
                    Green = table.Column<int>(nullable: false),
                    Blue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ColourTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueColours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrueColours_TrueTypes_ColourTypeId",
                        column: x => x.ColourTypeId,
                        principalTable: "TrueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrueColours_ColourTypeId",
                table: "TrueColours",
                column: "ColourTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueSyncLogDetails_SyncLogId",
                table: "TrueSyncLogDetails",
                column: "SyncLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrueColours");

            migrationBuilder.DropTable(
                name: "TrueSyncLogDetails");

            migrationBuilder.DropTable(
                name: "TrueTypes");

            migrationBuilder.DropTable(
                name: "TrueSyncLogs");
        }
    }
}
