using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class AjusteUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Usuario_Clave_NombreUsuario",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "Usuario_NombreUsuario_UQ",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Usuario_NombreUsuario_UQ",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "Usuario_Clave_NombreUsuario",
                table: "Usuarios",
                columns: new[] { "NombreUsuario", "Clave" });
        }
    }
}
