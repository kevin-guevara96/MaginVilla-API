using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagienUrl", "MetroCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa...", new DateTime(2024, 3, 26, 9, 17, 7, 89, DateTimeKind.Local).AddTicks(6869), new DateTime(2024, 3, 26, 9, 17, 7, 89, DateTimeKind.Local).AddTicks(6855), "", 50.0, "Villa Real", 5, 200.0 },
                    { 2, "", "Detalle de la Villa...", new DateTime(2024, 3, 26, 9, 17, 7, 89, DateTimeKind.Local).AddTicks(6872), new DateTime(2024, 3, 26, 9, 17, 7, 89, DateTimeKind.Local).AddTicks(6871), "", 40.0, "Premium Vista a la Piscina", 4, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
