using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDetalleVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "DetalleVenta_UQ",
                table: "DetalleVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVentas_VentaId",
                table: "DetalleVentas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "DetalleVentas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitario",
                table: "DetalleVentas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                table: "DetalleVentas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateIndex(
                name: "DetalleVenta_UQ",
                table: "DetalleVentas",
                columns: new[] { "VentaId", "ProductoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_ProductoId",
                table: "DetalleVentas",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "DetalleVenta_UQ",
                table: "DetalleVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVentas_ProductoId",
                table: "DetalleVentas");

            migrationBuilder.AlterColumn<string>(
                name: "Subtotal",
                table: "DetalleVentas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "PrecioUnitario",
                table: "DetalleVentas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Cantidad",
                table: "DetalleVentas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "DetalleVenta_UQ",
                table: "DetalleVentas",
                columns: new[] { "ProductoId", "PrecioUnitario" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_VentaId",
                table: "DetalleVentas",
                column: "VentaId");
        }
    }
}
