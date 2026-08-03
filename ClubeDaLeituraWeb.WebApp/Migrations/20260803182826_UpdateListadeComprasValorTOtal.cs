using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubeDaLeituraWeb.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateListadeComprasValorTOtal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "TB_ListaDeCompras",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "TB_ListaDeCompras");
        }
    }
}
