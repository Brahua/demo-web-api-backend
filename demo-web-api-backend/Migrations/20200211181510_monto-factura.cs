using Microsoft.EntityFrameworkCore.Migrations;

namespace demo_web_api_backend.Migrations
{
    public partial class montofactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesFactura_Facturas_FacturaId",
                table: "DetallesFactura");

            migrationBuilder.AlterColumn<int>(
                name: "MontoTotal",
                table: "Facturas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacturaId",
                table: "DetallesFactura",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesFactura_Facturas_FacturaId",
                table: "DetallesFactura",
                column: "FacturaId",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesFactura_Facturas_FacturaId",
                table: "DetallesFactura");

            migrationBuilder.AlterColumn<string>(
                name: "MontoTotal",
                table: "Facturas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FacturaId",
                table: "DetallesFactura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesFactura_Facturas_FacturaId",
                table: "DetallesFactura",
                column: "FacturaId",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
