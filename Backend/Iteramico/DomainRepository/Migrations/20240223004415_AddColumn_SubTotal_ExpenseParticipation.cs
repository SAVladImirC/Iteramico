using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainRepository.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_SubTotal_ExpenseParticipation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "ExpenseParticipations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "ExpenseParticipations");
        }
    }
}
