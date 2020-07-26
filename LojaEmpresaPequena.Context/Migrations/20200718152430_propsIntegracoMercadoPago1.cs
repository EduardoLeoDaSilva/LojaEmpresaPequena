using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaEmpresaPequena.Context.Migrations
{
    public partial class propsIntegracoMercadoPago1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatementDescriptor",
                table: "Pedido",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatementDescriptor",
                table: "Pedido");
        }
    }
}
