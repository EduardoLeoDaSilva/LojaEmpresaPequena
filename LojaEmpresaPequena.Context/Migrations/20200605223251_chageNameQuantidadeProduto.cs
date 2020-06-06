using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaEmpresaPequena.Context.Migrations
{
    public partial class chageNameQuantidadeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeEstoque",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Produto",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeEstoque",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
