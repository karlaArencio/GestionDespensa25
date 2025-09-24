using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class AjusteProveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Proveedor_UQ",
                table: "Proveedores");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaAlta",
                table: "Proveedores",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "Proveedor_CUIT_UQ",
                table: "Proveedores",
                column: "CUIT",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Proveedor_CUIT_UQ",
                table: "Proveedores");

            migrationBuilder.AlterColumn<string>(
                name: "FechaAlta",
                table: "Proveedores",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "Proveedor_UQ",
                table: "Proveedores",
                column: "Nombre",
                unique: true);
        }
    }
}
