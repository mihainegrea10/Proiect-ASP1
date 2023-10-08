using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP1.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "impresars");
        }
    }
}
