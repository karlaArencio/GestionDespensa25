using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDespensa25.BD.Migrations
{
    /// <inheritdoc />
    public partial class AgregoMaxlongDC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Venta_Estado_TipoPago",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCajas_CajaId",
                table: "DetalleCajas");

            migrationBuilder.AlterColumn<string>(
                name: "TipoMovimiento",
                table: "DetalleCajas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Referencia",
                table: "DetalleCajas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Monto",
                table: "DetalleCajas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FechaHora",
                table: "DetalleCajas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "DetalleCajas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Venta_Estado_TipoPago",
                table: "Ventas",
                columns: new[] { "CajaId", "TipoPago" });

            migrationBuilder.CreateIndex(
                name: "DetalleCaja_UQ",
                table: "DetalleCajas",
                columns: new[] { "CajaId", "FechaHora" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Venta_Estado_TipoPago",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "DetalleCaja_UQ",
                table: "DetalleCajas");

            migrationBuilder.AlterColumn<string>(
                name: "TipoMovimiento",
                table: "DetalleCajas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Referencia",
                table: "DetalleCajas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Monto",
                table: "DetalleCajas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "FechaHora",
                table: "DetalleCajas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "DetalleCajas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "Venta_Estado_TipoPago",
                table: "Ventas",
                columns: new[] { "CajaId", "TipoPago" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCajas_CajaId",
                table: "DetalleCajas",
                column: "CajaId");
        }
    }
}
