using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainRepository.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_TravelBuddies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelBuddies",
                columns: table => new
                {
                    User1Id = table.Column<int>(type: "int", nullable: false),
                    User2Id = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelBuddies", x => new { x.User1Id, x.User2Id });
                    table.ForeignKey(
                        name: "FK_TravelBuddies_Users_User1Id",
                        column: x => x.User1Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelBuddies_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelBuddies_User2Id",
                table: "TravelBuddies",
                column: "User2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelBuddies");
        }
    }
}
