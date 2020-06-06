using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaEmpresaPequena.Context.Migrations
{
    public partial class NovaPropriedades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPedido",
                table: "DetalhesPedido");

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Produto",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusPedido",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusEnvio",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEnvio",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPedido",
                table: "Pedido",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAprovacao",
                table: "DetalhesPedido",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoPagamento",
                table: "DetalhesPedido",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoDeArea",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SobreNome",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CodigoPedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "TipoPagamento",
                table: "DetalhesPedido");

            migrationBuilder.DropColumn(
                name: "CodigoDeArea",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SobreNome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StatusPedido",
                table: "Pedido",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusEnvio",
                table: "Pedido",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "Pedido",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEnvio",
                table: "Pedido",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataAprovacao",
                table: "DetalhesPedido",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPedido",
                table: "DetalhesPedido",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
