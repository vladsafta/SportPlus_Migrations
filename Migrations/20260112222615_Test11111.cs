using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportPlus.Migrations
{
    /// <inheritdoc />
    public partial class Test11111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Cos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Cos",
                type: "text",
                nullable: true);
        }
    }
}
