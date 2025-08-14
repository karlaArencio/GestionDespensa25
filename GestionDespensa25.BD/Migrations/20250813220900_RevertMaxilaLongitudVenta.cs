using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class RevertMaxilaLongitudVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "Venta_UQ",
            table: "Ventas");

            migrationBuilder.DropIndex(
                name: "Venta_Estado_TipoPago",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "Cliente_UQ",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "Caja_UQ",
                table: "Ventas",
                columns: new[] { "CajaId", "TipoPago" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Cliente_UQ",
                table: "Clientes",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Caja_UQ",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "Cliente_UQ",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "Venta_Estado_TipoPago",
                table: "Ventas",
                columns: new[] { "CajaId", "TipoPago" });

            migrationBuilder.CreateIndex(
                name: "Cliente_UQ",
                table: "Clientes",
                column: "DNI",
                unique: true);
        }
    }
}
