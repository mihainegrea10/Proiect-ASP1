using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP1.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "antrenors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nume_familie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_nastere = table.Column<DateTime>(type: "datetime2", nullable: true),
                    trofee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_antrenors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "impresars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nume_familie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jucatori_impresariati = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_impresars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "echipas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localitate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Infiintare = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AntrenorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_echipas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_echipas_antrenors_AntrenorId",
                        column: x => x.AntrenorId,
                        principalTable: "antrenors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jucators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nume_familie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aparitii = table.Column<int>(type: "int", nullable: false),
                    goluri = table.Column<int>(type: "int", nullable: false),
                    ImpresarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jucators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jucators_impresars_ImpresarId",
                        column: x => x.ImpresarId,
                        principalTable: "impresars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "echipa_cont_juc",
                columns: table => new
                {
                    EchipaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JucatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_echipa_cont_juc", x => new { x.EchipaId, x.JucatorId });
                    table.ForeignKey(
                        name: "FK_echipa_cont_juc_echipas_EchipaId",
                        column: x => x.EchipaId,
                        principalTable: "echipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_echipa_cont_juc_jucators_JucatorId",
                        column: x => x.JucatorId,
                        principalTable: "jucators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_echipa_cont_juc_JucatorId",
                table: "echipa_cont_juc",
                column: "JucatorId");

            migrationBuilder.CreateIndex(
                name: "IX_echipas_AntrenorId",
                table: "echipas",
                column: "AntrenorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_jucators_ImpresarId",
                table: "jucators",
                column: "ImpresarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "echipa_cont_juc");

            migrationBuilder.DropTable(
                name: "echipas");

            migrationBuilder.DropTable(
                name: "jucators");

            migrationBuilder.DropTable(
                name: "antrenors");

            migrationBuilder.DropTable(
                name: "impresars");
        }
    }
}
