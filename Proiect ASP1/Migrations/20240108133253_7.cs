using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP1.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_echipas_antrenors_AntrenorId",
                table: "echipas");

            migrationBuilder.DropForeignKey(
                name: "FK_jucators_impresars_ImpresarId",
                table: "jucators");

            migrationBuilder.DropIndex(
                name: "IX_echipas_AntrenorId",
                table: "echipas");

            migrationBuilder.AlterColumn<int>(
                name: "varsta",
                table: "jucators",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImpresarId",
                table: "jucators",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AntrenorId",
                table: "echipas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_echipas_AntrenorId",
                table: "echipas",
                column: "AntrenorId",
                unique: true,
                filter: "[AntrenorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_echipas_antrenors_AntrenorId",
                table: "echipas",
                column: "AntrenorId",
                principalTable: "antrenors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_jucators_impresars_ImpresarId",
                table: "jucators",
                column: "ImpresarId",
                principalTable: "impresars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_echipas_antrenors_AntrenorId",
                table: "echipas");

            migrationBuilder.DropForeignKey(
                name: "FK_jucators_impresars_ImpresarId",
                table: "jucators");

            migrationBuilder.DropIndex(
                name: "IX_echipas_AntrenorId",
                table: "echipas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "varsta",
                table: "jucators",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImpresarId",
                table: "jucators",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AntrenorId",
                table: "echipas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_echipas_AntrenorId",
                table: "echipas",
                column: "AntrenorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_echipas_antrenors_AntrenorId",
                table: "echipas",
                column: "AntrenorId",
                principalTable: "antrenors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jucators_impresars_ImpresarId",
                table: "jucators",
                column: "ImpresarId",
                principalTable: "impresars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
