using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportPlus.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorii",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorii", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    ProduseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stoc = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.ProduseId);
                    table.ForeignKey(
                        name: "FK_Produse_Categorii_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorii",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DataComanda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PretTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comenzi_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacte",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataMesaj = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacte", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacte_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cosuri",
                columns: table => new
                {
                    CosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosuri", x => x.CosId);
                    table.ForeignKey(
                        name: "FK_Cosuri_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaItems",
                columns: table => new
                {
                    ComandaItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaItems", x => x.ComandaItemId);
                    table.ForeignKey(
                        name: "FK_ComandaItems_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaItems_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "ProduseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CosItems",
                columns: table => new
                {
                    CosItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CosId = table.Column<int>(type: "int", nullable: false),
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosItems", x => x.CosItemId);
                    table.ForeignKey(
                        name: "FK_CosItems_Cosuri_CosId",
                        column: x => x.CosId,
                        principalTable: "Cosuri",
                        principalColumn: "CosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CosItems_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "ProduseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItems_ComandaId",
                table: "ComandaItems",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItems_ProdusId",
                table: "ComandaItems",
                column: "ProdusId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_UserId",
                table: "Comenzi",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacte_UserId",
                table: "Contacte",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CosItems_CosId",
                table: "CosItems",
                column: "CosId");

            migrationBuilder.CreateIndex(
                name: "IX_CosItems_ProdusId",
                table: "CosItems",
                column: "ProdusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cosuri_UserId",
                table: "Cosuri",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produse_CategoryId",
                table: "Produse",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaItems");

            migrationBuilder.DropTable(
                name: "Contacte");

            migrationBuilder.DropTable(
                name: "CosItems");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Cosuri");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categorii");
        }
    }
}
