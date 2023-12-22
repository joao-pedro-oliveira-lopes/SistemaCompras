using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AddSolicitacaoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "SolicitacaoCompra",
                newName: "SolicitacoesCompra");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGeral",
                table: "SolicitacoesCompra",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CondicaoPagamentoId",
                table: "SolicitacoesCompra",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NomeFornecedorId",
                table: "SolicitacoesCompra",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioSolicitanteId",
                table: "SolicitacoesCompra",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacoesCompra",
                table: "SolicitacoesCompra",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CondicaoPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CondicaoPagamentoId = table.Column<int>(nullable: false),
                    Valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicaoPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NomeFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSolicitante",
                columns: table => new
                {
                    UsuarioSolicitanteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSolicitante", x => x.UsuarioSolicitanteId);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("ba4621e9-854e-4faf-ae3c-0680b8abcf6f"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesCompra_CondicaoPagamentoId",
                table: "SolicitacoesCompra",
                column: "CondicaoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesCompra_NomeFornecedorId",
                table: "SolicitacoesCompra",
                column: "NomeFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesCompra_UsuarioSolicitanteId",
                table: "SolicitacoesCompra",
                column: "UsuarioSolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitacoesCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacoesCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacoesCompra_CondicaoPagamento_CondicaoPagamentoId",
                table: "SolicitacoesCompra",
                column: "CondicaoPagamentoId",
                principalTable: "CondicaoPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacoesCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitacoesCompra",
                column: "NomeFornecedorId",
                principalTable: "NomeFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacoesCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacoesCompra",
                column: "UsuarioSolicitanteId",
                principalTable: "UsuarioSolicitante",
                principalColumn: "UsuarioSolicitanteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitacoesCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacoesCompra_CondicaoPagamento_CondicaoPagamentoId",
                table: "SolicitacoesCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacoesCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitacoesCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacoesCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacoesCompra");

            migrationBuilder.DropTable(
                name: "CondicaoPagamento");

            migrationBuilder.DropTable(
                name: "NomeFornecedor");

            migrationBuilder.DropTable(
                name: "UsuarioSolicitante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacoesCompra",
                table: "SolicitacoesCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacoesCompra_CondicaoPagamentoId",
                table: "SolicitacoesCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacoesCompra_NomeFornecedorId",
                table: "SolicitacoesCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacoesCompra_UsuarioSolicitanteId",
                table: "SolicitacoesCompra");

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("ba4621e9-854e-4faf-ae3c-0680b8abcf6f"));

            migrationBuilder.DropColumn(
                name: "CondicaoPagamentoId",
                table: "SolicitacoesCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedorId",
                table: "SolicitacoesCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitanteId",
                table: "SolicitacoesCompra");

            migrationBuilder.RenameTable(
                name: "SolicitacoesCompra",
                newName: "SolicitacaoCompra");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGeral",
                table: "SolicitacaoCompra",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
