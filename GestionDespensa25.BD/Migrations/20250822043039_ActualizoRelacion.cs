using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizoRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Cajas_CajaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_CajaId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "CajaId",
                table: "Ventas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CajaId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_CajaId",
                table: "Ventas",
                column: "CajaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Cajas_CajaId",
                table: "Ventas",
                column: "CajaId",
                principalTable: "Cajas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
