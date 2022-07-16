using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrueColoursAPI.Migrations
{
    public partial class synclogs : Migration
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
                name: "TrueSyncLogDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<int>(nullable: false),
                    ColourId = table.Column<int>(nullable: true),
                    SyncLogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueSyncLogDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrueSyncLogDetails_TrueColours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "TrueColours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrueSyncLogDetails_TrueSyncLogs_SyncLogId",
                        column: x => x.SyncLogId,
                        principalTable: "TrueSyncLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrueSyncLogDetails_ColourId",
                table: "TrueSyncLogDetails",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueSyncLogDetails_SyncLogId",
                table: "TrueSyncLogDetails",
                column: "SyncLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrueSyncLogDetails");

            migrationBuilder.DropTable(
                name: "TrueSyncLogs");
        }
    }
}
