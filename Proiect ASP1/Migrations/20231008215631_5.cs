using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP1.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImpresarId",
                table: "jucators",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_jucators_ImpresarId",
                table: "jucators",
                column: "ImpresarId");

            migrationBuilder.AddForeignKey(
                name: "FK_jucators_impresars_ImpresarId",
                table: "jucators",
                column: "ImpresarId",
                principalTable: "impresars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jucators_impresars_ImpresarId",
                table: "jucators");

            migrationBuilder.DropIndex(
                name: "IX_jucators_ImpresarId",
                table: "jucators");

            migrationBuilder.DropColumn(
                name: "ImpresarId",
                table: "jucators");
        }
    }
}
