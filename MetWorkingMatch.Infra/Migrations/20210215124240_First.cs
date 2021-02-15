using Microsoft.EntityFrameworkCore.Migrations;

namespace MetWorkingMatch.Infra.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosMatch_StatusPedido_idStatusSolicitacaoId",
                table: "PedidosMatch");

            migrationBuilder.RenameColumn(
                name: "descricaoStatus",
                table: "StatusPedido",
                newName: "DescricaoStatus");

            migrationBuilder.RenameColumn(
                name: "idStatusSolicitacaoId",
                table: "PedidosMatch",
                newName: "IdStatusSolicitacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosMatch_idStatusSolicitacaoId",
                table: "PedidosMatch",
                newName: "IX_PedidosMatch_IdStatusSolicitacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosMatch_StatusPedido_IdStatusSolicitacaoId",
                table: "PedidosMatch",
                column: "IdStatusSolicitacaoId",
                principalTable: "StatusPedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosMatch_StatusPedido_IdStatusSolicitacaoId",
                table: "PedidosMatch");

            migrationBuilder.RenameColumn(
                name: "DescricaoStatus",
                table: "StatusPedido",
                newName: "descricaoStatus");

            migrationBuilder.RenameColumn(
                name: "IdStatusSolicitacaoId",
                table: "PedidosMatch",
                newName: "idStatusSolicitacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosMatch_IdStatusSolicitacaoId",
                table: "PedidosMatch",
                newName: "IX_PedidosMatch_idStatusSolicitacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosMatch_StatusPedido_idStatusSolicitacaoId",
                table: "PedidosMatch",
                column: "idStatusSolicitacaoId",
                principalTable: "StatusPedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
