using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaEmpresaPequena.Context.Migrations
{
    public partial class migrationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Pedido",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pedido");
        }
    }
}
