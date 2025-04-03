using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportPlus.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Categorii_CategoryId",
                table: "Produse");

            migrationBuilder.DropIndex(
                name: "IX_Produse_CategoryId",
                table: "Produse");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Produse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produse_CategorieId",
                table: "Produse",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Categorii_CategorieId",
                table: "Produse",
                column: "CategorieId",
                principalTable: "Categorii",
                principalColumn: "CategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Categorii_CategorieId",
                table: "Produse");

            migrationBuilder.DropIndex(
                name: "IX_Produse_CategorieId",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Produse");

            migrationBuilder.CreateIndex(
                name: "IX_Produse_CategoryId",
                table: "Produse",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Categorii_CategoryId",
                table: "Produse",
                column: "CategoryId",
                principalTable: "Categorii",
                principalColumn: "CategorieId");
        }
    }
}
