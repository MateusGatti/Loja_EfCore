using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore.Migrations
{
    public partial class AlterTableProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "PedidosItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "PedidosItems");
        }
    }
}
