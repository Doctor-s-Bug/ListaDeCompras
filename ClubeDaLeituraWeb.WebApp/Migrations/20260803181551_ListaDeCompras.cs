using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubeDaLeituraWeb.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ListaDeCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensProdutos_ListasDeCompras_ListaDeCompraId",
                table: "ItensProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensProdutos_Produtos_ProdutoId",
                table: "ItensProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_TB_Categorias_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListasDeCompras",
                table: "ListasDeCompras");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "TB_Produto");

            migrationBuilder.RenameTable(
                name: "ListasDeCompras",
                newName: "TB_ListaDeCompras");

            migrationBuilder.RenameColumn(
                name: "ListaDeCompraId",
                table: "ItensProdutos",
                newName: "ItensProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensProdutos_ListaDeCompraId",
                table: "ItensProdutos",
                newName: "IX_ItensProdutos_ItensProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaId",
                table: "TB_Produto",
                newName: "IX_TB_Produto_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_Produto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_ListaDeCompras",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBProduto",
                table: "TB_Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListaDeCompras",
                table: "TB_ListaDeCompras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensProdutos_TB_Produto_ProdutoId",
                table: "ItensProdutos",
                column: "ProdutoId",
                principalTable: "TB_Produto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBListaDeCompras_TBItensProduto",
                table: "ItensProdutos",
                column: "ItensProdutoId",
                principalTable: "TB_ListaDeCompras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBProduto_TBCategoria",
                table: "TB_Produto",
                column: "CategoriaId",
                principalTable: "TB_Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensProdutos_TB_Produto_ProdutoId",
                table: "ItensProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBListaDeCompras_TBItensProduto",
                table: "ItensProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBProduto_TBCategoria",
                table: "TB_Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBProduto",
                table: "TB_Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListaDeCompras",
                table: "TB_ListaDeCompras");

            migrationBuilder.RenameTable(
                name: "TB_Produto",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "TB_ListaDeCompras",
                newName: "ListasDeCompras");

            migrationBuilder.RenameColumn(
                name: "ItensProdutoId",
                table: "ItensProdutos",
                newName: "ListaDeCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensProdutos_ItensProdutoId",
                table: "ItensProdutos",
                newName: "IX_ItensProdutos_ListaDeCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Produto_CategoriaId",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ListasDeCompras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListasDeCompras",
                table: "ListasDeCompras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensProdutos_ListasDeCompras_ListaDeCompraId",
                table: "ItensProdutos",
                column: "ListaDeCompraId",
                principalTable: "ListasDeCompras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensProdutos_Produtos_ProdutoId",
                table: "ItensProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_TB_Categorias_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "TB_Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
