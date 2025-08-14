using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class MaximaLongitudDetalleCompraProveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetalleCompraProveedores_ProductoId",
                table: "DetalleCompraProveedores");

            migrationBuilder.AlterColumn<string>(
                name: "PrecioUnitario",
                table: "DetalleCompraProveedores",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cantidad",
                table: "DetalleCompraProveedores",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "DetalleCompraProveedor_UQ",
                table: "DetalleCompraProveedores",
                columns: new[] { "ProductoId", "Cantidad" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "DetalleCompraProveedor_UQ",
                table: "DetalleCompraProveedores");

            migrationBuilder.AlterColumn<string>(
                name: "PrecioUnitario",
                table: "DetalleCompraProveedores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Cantidad",
                table: "DetalleCompraProveedores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompraProveedores_ProductoId",
                table: "DetalleCompraProveedores",
                column: "ProductoId");
        }
    }
}
