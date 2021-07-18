using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetWorkingMatch.Infra.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdUser = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdAmigo = table.Column<Guid>(type: "char(36)", nullable: false),
                    dataConexao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescricaoStatus = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosMatch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdUserSolicitante = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdUserAprovador = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdStatusSolicitacaoId = table.Column<int>(type: "int", nullable: true),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAceite = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosMatch_StatusPedido_IdStatusSolicitacaoId",
                        column: x => x.IdStatusSolicitacaoId,
                        principalTable: "StatusPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "StatusPedido",
                columns: new[] { "Id", "DescricaoStatus" },
                values: new object[] { 1, "Pendente" });

            migrationBuilder.InsertData(
                table: "StatusPedido",
                columns: new[] { "Id", "DescricaoStatus" },
                values: new object[] { 2, "Aceito" });

            migrationBuilder.InsertData(
                table: "StatusPedido",
                columns: new[] { "Id", "DescricaoStatus" },
                values: new object[] { 3, "Recusado" });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosMatch_IdStatusSolicitacaoId",
                table: "PedidosMatch",
                column: "IdStatusSolicitacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "PedidosMatch");

            migrationBuilder.DropTable(
                name: "StatusPedido");
        }
    }
}
