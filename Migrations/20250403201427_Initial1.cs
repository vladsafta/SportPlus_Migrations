using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportPlus.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Categorii_CategoryId",
                table: "Produse");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Produse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Categorii_CategoryId",
                table: "Produse",
                column: "CategoryId",
                principalTable: "Categorii",
                principalColumn: "CategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Categorii_CategoryId",
                table: "Produse");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Produse",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Categorii_CategoryId",
                table: "Produse",
                column: "CategoryId",
                principalTable: "Categorii",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
