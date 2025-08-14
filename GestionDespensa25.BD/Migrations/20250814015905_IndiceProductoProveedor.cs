using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class IndiceProductoProveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductoProveedores_ProductoId",
                table: "ProductoProveedores");

            migrationBuilder.CreateIndex(
                name: "ProductoProveedor_UQ",
                table: "ProductoProveedores",
                column: "ProductoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ProductoProveedor_UQ",
                table: "ProductoProveedores");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoProveedores_ProductoId",
                table: "ProductoProveedores",
                column: "ProductoId");
        }
    }
}
