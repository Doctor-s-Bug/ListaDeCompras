using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubeDaLeituraWeb.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Categoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListasDeCompras",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusLista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasDeCompras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Categorias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoAproximado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoriaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_TB_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TB_Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensProdutos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProdutoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false),
                    ListaDeCompraId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensProdutos_ListasDeCompras_ListaDeCompraId",
                        column: x => x.ListaDeCompraId,
                        principalTable: "ListasDeCompras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItensProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensProdutos_ListaDeCompraId",
                table: "ItensProdutos",
                column: "ListaDeCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensProdutos_ProdutoId",
                table: "ItensProdutos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensProdutos");

            migrationBuilder.DropTable(
                name: "ListasDeCompras");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "TB_Categorias");
        }
    }
}
