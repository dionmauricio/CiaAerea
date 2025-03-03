using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CiaAerea.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aeronaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fabricante = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "text", maxLength: 10, nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aeronaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pilotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCompleto = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    Matricula = table.Column<string>(type: "text", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pilotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manutencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Observacao = table.Column<string>(type: "text", maxLength: 100, nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    AeronaveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manutencoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_manutencoes_aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "voos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Origem = table.Column<string>(type: "text", maxLength: 3, nullable: false),
                    Destino = table.Column<string>(type: "text", maxLength: 3, nullable: false),
                    DataHoraPartida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraChegada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AeronaveId = table.Column<int>(type: "integer", nullable: false),
                    PilotoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_voos_aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_voos_pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cancelamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Motivo = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    DataHoraNotificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VooId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cancelamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cancelamentos_voos_VooId",
                        column: x => x.VooId,
                        principalTable: "voos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cancelamentos_VooId",
                table: "cancelamentos",
                column: "VooId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_manutencoes_AeronaveId",
                table: "manutencoes",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_pilotos_Matricula",
                table: "pilotos",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_voos_AeronaveId",
                table: "voos",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_voos_PilotoId",
                table: "voos",
                column: "PilotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cancelamentos");

            migrationBuilder.DropTable(
                name: "manutencoes");

            migrationBuilder.DropTable(
                name: "voos");

            migrationBuilder.DropTable(
                name: "aeronaves");

            migrationBuilder.DropTable(
                name: "pilotos");
        }
    }
}
