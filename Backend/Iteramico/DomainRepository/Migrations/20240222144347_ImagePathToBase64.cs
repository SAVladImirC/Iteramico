using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainRepository.Migrations
{
    /// <inheritdoc />
    public partial class ImagePathToBase64 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Memories");

            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "Memories",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "Memories");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Memories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
