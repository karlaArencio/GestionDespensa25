using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Cliente_UQ",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "Cliente_DNI_UQ",
                table: "Clientes",
                column: "DNI",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Cliente_DNI_UQ",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "Cliente_UQ",
                table: "Clientes",
                column: "Nombre",
                unique: true);
        }
    }
}
