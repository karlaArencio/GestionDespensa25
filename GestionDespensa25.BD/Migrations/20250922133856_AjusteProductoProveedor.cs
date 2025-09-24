using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class AjusteProductoProveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ProductoProveedor_UQ",
                table: "ProductoProveedores");

            migrationBuilder.CreateIndex(
                name: "ProductoProveedor_UQ",
                table: "ProductoProveedores",
                columns: new[] { "ProductoId", "ProveedorId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ProductoProveedor_UQ",
                table: "ProductoProveedores");

            migrationBuilder.CreateIndex(
                name: "ProductoProveedor_UQ",
                table: "ProductoProveedores",
                column: "ProductoId",
                unique: true);
        }
    }
}
