using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaEmpresaPequena.Context.Migrations
{
    public partial class CadascadeDeleteFotosByProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Produto_ProdutoId",
                table: "Foto");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Produto_ProdutoId",
                table: "Foto",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Produto_ProdutoId",
                table: "Foto");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Produto_ProdutoId",
                table: "Foto",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
