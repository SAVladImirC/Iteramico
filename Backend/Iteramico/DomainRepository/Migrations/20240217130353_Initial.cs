using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainRepository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LocalName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, defaultValue: ""),
                    LastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, defaultValue: ""),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: ""),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LocalName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LoginAttempts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Auth_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journey_City_ToId",
                        column: x => x.ToId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Journey_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    JourneyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Journey_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    JourneyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_Journey_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expense_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JourneyParticipation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JourneyId = table.Column<int>(type: "int", nullable: false),
                    JoinedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyParticipation", x => new { x.UserId, x.JourneyId });
                    table.ForeignKey(
                        name: "FK_JourneyParticipation_Journey_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JourneyParticipation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ForId = table.Column<int>(type: "int", nullable: false),
                    JourneyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Journey_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reminder_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reminder_User_ForId",
                        column: x => x.ForId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseParticipation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    PayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseParticipation", x => new { x.UserId, x.ExpenseId });
                    table.ForeignKey(
                        name: "FK_ExpenseParticipation_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseParticipation_User_PayerId",
                        column: x => x.PayerId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseParticipation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CreatorId",
                table: "Event",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_JourneyId",
                table: "Event",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CreatorId",
                table: "Expense",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_JourneyId",
                table: "Expense",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseParticipation_ExpenseId",
                table: "ExpenseParticipation",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseParticipation_PayerId",
                table: "ExpenseParticipation",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Journey_CreatorId",
                table: "Journey",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Journey_ToId",
                table: "Journey",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyParticipation_JourneyId",
                table: "JourneyParticipation",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_CreatorId",
                table: "Reminder",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_ForId",
                table: "Reminder",
                column: "ForId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_JourneyId",
                table: "Reminder",
                column: "JourneyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ExpenseParticipation");

            migrationBuilder.DropTable(
                name: "JourneyParticipation");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Journey");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
