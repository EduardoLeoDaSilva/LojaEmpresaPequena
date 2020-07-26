using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaEmpresaPequena.Context.Migrations
{
    public partial class statusMessageDetaileMercadoPago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusDetailed",
                table: "Pedido",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDetailed",
                table: "Pedido");
        }
    }
}
