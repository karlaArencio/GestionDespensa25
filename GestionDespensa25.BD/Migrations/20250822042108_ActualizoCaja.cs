using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizoCaja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Cajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cajas_UsuarioId",
                table: "Cajas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cajas_Usuarios_UsuarioId",
                table: "Cajas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Usuarios_UsuarioId",
                table: "Ventas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cajas_Usuarios_UsuarioId",
                table: "Cajas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Usuarios_UsuarioId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Cajas_UsuarioId",
                table: "Cajas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Cajas");
        }
    }
}
