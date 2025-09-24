using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDetalleCaja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "DetalleCaja_UQ",
                table: "DetalleCajas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "DetalleCajas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "DetalleCajas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "DetalleCaja_IDX",
                table: "DetalleCajas",
                columns: new[] { "CajaId", "FechaHora" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "DetalleCaja_IDX",
                table: "DetalleCajas");

            migrationBuilder.AlterColumn<string>(
                name: "Monto",
                table: "DetalleCajas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "FechaHora",
                table: "DetalleCajas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "DetalleCaja_UQ",
                table: "DetalleCajas",
                columns: new[] { "CajaId", "FechaHora" },
                unique: true);
        }
    }
}
